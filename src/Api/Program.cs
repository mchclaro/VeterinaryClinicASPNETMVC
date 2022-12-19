using System.Text.Json.Serialization;
using Data.Context;
using Data.Repositories;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<DataContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
            );

// Register repositories
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IVeterinaryRepository, VeterinaryRepository>();
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();

builder.Services.AddScoped<Mediator>();

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "VeterinaryClinic.API", Version = "v1" });
  c.CustomSchemaIds(type => type.FullName);
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    Description = "JWT Authorization header using the Bearer scheme",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    In = ParameterLocation.Header,
    Scheme = "Bearer",
  });
});
builder.Services.AddCors();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvcCore()
                .AddRazorViewEngine()
                .AddRazorRuntimeCompilation()
                .ConfigureApiBehaviorOptions(options =>
                {
                  options.InvalidModelStateResponseFactory = actionContext =>
                  {
                    var result = new Api.Result.StandardResult<object> { };
                    var errors = actionContext.ModelState.Values
                          .Where(v => v.Errors.Count > 0)
                          .SelectMany(v => v.Errors);
                    foreach (var error in errors)
                    {
                      result.AddError(Api.Result.Code.BadRequest, error.ErrorMessage);
                    };
                    var responseBody = result.GetResult().Body;
                    return new BadRequestObjectResult(responseBody);
                  };
                });
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks();

var app = builder.Build();

IConfiguration configuration = app.Configuration;
IWebHostEnvironment hostEnvironment = app.Environment;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  // app.UseExceptionHandler("/Home/Error");
  // // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  // app.UseHsts();
  app.UseDeveloperExceptionPage();
  app.UseSwagger();
  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estagio.API v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
