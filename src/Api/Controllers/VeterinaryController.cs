using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  public class VeterinaryController : Controller
  {
    private readonly IVeterinaryRepository _veterinaryRepository;
    public VeterinaryController(IVeterinaryRepository veterinaryRepository)
    {
      _veterinaryRepository = veterinaryRepository;
    }

    public async Task<IActionResult> Index()
    {
      return View(await _veterinaryRepository.ReadAll());
    }
    public IActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Veterinary veterinary)
    {
      try
      {
        if (ModelState.IsValid)
        {
          await _veterinaryRepository.Create(veterinary);
          return RedirectToAction("Index");
        }

        return View(veterinary);
      }
      catch (System.Exception)
      {
        TempData["Erro"] = "Falha ao salvar!";
        return RedirectToAction("Index");
      }
    }

    public async Task<IActionResult> Update(int id)
    {
      var veterinary = await _veterinaryRepository.Read(id);
      return View(veterinary);
    }
    [HttpPost]
    public async Task<IActionResult> Update(Veterinary veterinary)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          await _veterinaryRepository.Update(veterinary);
          TempData["Sucesso"] = "Salvo com sucesso!";
          return RedirectToAction("Index");
        }
        return View(veterinary);
      }
      catch (System.Exception)
      {
        TempData["Erro"] = "Falha ao salvar!";
        return RedirectToAction("Index");
      }
    }

    public async Task<IActionResult> Delete(int id)
    {
      Veterinary veterinary = await _veterinaryRepository.Read(id);
      return View(veterinary);
    }

    public async Task<IActionResult> ConfirmDelete(int id)
    {
      await _veterinaryRepository.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
