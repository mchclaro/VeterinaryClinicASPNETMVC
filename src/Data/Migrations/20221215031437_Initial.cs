using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
  /// <inheritdoc />
  public partial class Initial : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Animal",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Age = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Animal", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Veterinary",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Veterinary", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Treatment",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
            AnimalId = table.Column<int>(type: "int", nullable: false),
            VeterinaryId = table.Column<int>(type: "int", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Treatment", x => x.Id);
            table.ForeignKey(
                      name: "FK_Treatment_Animal_AnimalId",
                      column: x => x.AnimalId,
                      principalTable: "Animal",
                      principalColumn: "Id");
            table.ForeignKey(
                      name: "FK_Treatment_Veterinary_VeterinaryId",
                      column: x => x.VeterinaryId,
                      principalTable: "Veterinary",
                      principalColumn: "Id");
          });

      migrationBuilder.CreateIndex(
          name: "IX_Treatment_AnimalId",
          table: "Treatment",
          column: "AnimalId",
          unique: true);

      migrationBuilder.CreateIndex(
          name: "IX_Treatment_VeterinaryId",
          table: "Treatment",
          column: "VeterinaryId",
          unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Treatment");

      migrationBuilder.DropTable(
          name: "Animal");

      migrationBuilder.DropTable(
          name: "Veterinary");
    }
  }
}
