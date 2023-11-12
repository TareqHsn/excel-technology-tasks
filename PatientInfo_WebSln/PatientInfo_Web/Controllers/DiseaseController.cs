using Microsoft.AspNetCore.Mvc;
using PatientInfo_Web.Models.DTOs;
using PatientInfo_Web.Services;

namespace PatientInfo_Web.Controllers
{
    public class DiseaseController : Controller
    {
        private readonly DiseaseApiService _diseaseApiService;

        public DiseaseController(DiseaseApiService diseaseApiService)
        {
            _diseaseApiService = diseaseApiService;
        }

        public async Task<IActionResult> Index()
        {
            var diseases = await _diseaseApiService.GetDiseases();
            return View(diseases);
        }

        public async Task<IActionResult> Details(int id)
        {
            var disease = await _diseaseApiService.GetDiseaseById(id);

            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }     

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Disease disease)
        {
            if (ModelState.IsValid)
            {
                await _diseaseApiService.AddDisease(disease);
                return RedirectToAction("Index");
            }

            return View(disease);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var disease = await _diseaseApiService.GetDiseaseById(id);

            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Disease disease)
        {
            if (ModelState.IsValid)
            {
                await _diseaseApiService.UpdateDisease(id, disease);
                return RedirectToAction("Index");
            }

            return View(disease);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var disease = await _diseaseApiService.GetDiseaseById(id);

            if (disease == null)
            {
                return NotFound();
            }

            return View(disease);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _diseaseApiService.DeleteDisease(id);
            return RedirectToAction("Index");
        }
    }

}
