using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  public class TreatmentController : Controller
  {
    private readonly ITreatmentRepository _treatmentRepository;
    public TreatmentController(ITreatmentRepository treatmentRepository)
    {
      _treatmentRepository = treatmentRepository;
    }
    public async Task<IActionResult> Index()
    {
      return View(await _treatmentRepository.ReadAll());
    }
    public IActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Treatment treatment)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          await _treatmentRepository.Create(treatment);
          return RedirectToAction("Index");
        }
        return View(treatment);
      }
      catch (System.Exception)
      {
        TempData["Erro"] = "Falha ao salvar!";
        return RedirectToAction("Index");
      }
    }

    public async Task<IActionResult> Update(int id)
    {
      var treatment = await _treatmentRepository.Read(id);
      return View(treatment);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Treatment treatment)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          await _treatmentRepository.Update(treatment);
          TempData["Sucesso"] = "Salvo com sucesso!";
          return RedirectToAction("Index");
        }
        return View(treatment);
      }
      catch (System.Exception)
      {
        TempData["Erro"] = "Falha ao salvar!";
        return RedirectToAction("Index");
      }
    }
    public async Task<IActionResult> Delete(int id)
    {
      Treatment treatment = await _treatmentRepository.Read(id);
      return View(treatment);
    }

    public async Task<IActionResult> ConfirmDelete(int id)
    {
      await _treatmentRepository.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
