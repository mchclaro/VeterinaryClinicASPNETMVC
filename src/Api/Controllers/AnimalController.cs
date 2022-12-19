using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  public class AnimalController : Controller
  {
    private readonly IAnimalRepository _animalRepository;
    public AnimalController(IAnimalRepository animalRepository)
    {
      _animalRepository = animalRepository;
    }

    public async Task<IActionResult> Index()
    {
      return View(await _animalRepository.ReadAll());
    }
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Animal animal)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          await _animalRepository.Create(animal);
          TempData["Sucesso"] = "Salvo com sucesso!";
          return RedirectToAction("Index");
        }
        return View(animal);
      }
      catch (System.Exception)
      {
        TempData["Erro"] = "Falha ao salvar!";
        return RedirectToAction("Index");
      }
    }

    public async Task<IActionResult> Update(int id)
    {
      var animal = await _animalRepository.Read(id);
      return View(animal);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Animal animal)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          await _animalRepository.Update(animal);
          TempData["Sucesso"] = "Salvo com sucesso!";
          return RedirectToAction("Index");
        }
        return View(animal);
      }
      catch (System.Exception)
      {
        TempData["Erro"] = "Falha ao salvar!";
        return RedirectToAction("Index");
      }
    }

    public async Task<IActionResult> Delete(int id)
    {
      Animal animal = await _animalRepository.Read(id);
      return View(animal);
    }

    public async Task<IActionResult> ConfirmDelete(int id)
    {
      await _animalRepository.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
