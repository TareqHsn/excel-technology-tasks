using Microsoft.AspNetCore.Mvc;
using PatientInfo_Web.Models.DTOs;
using PatientInfo_Web.Services;

namespace PatientInfo_Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly PatientApiService _patientApiService;

        public PatientController(PatientApiService patientApiService)
        {
            _patientApiService = patientApiService;
        }

        public async Task<IActionResult> Index()
        {

            var patients = await _patientApiService.GetPatients();
            return View(patients);
        }

        public async Task<IActionResult> Details(int id)
        {
            var patient = await _patientApiService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                await _patientApiService.AddPatient(patient);
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _patientApiService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Patient patient)
        {
            if (ModelState.IsValid)
            {
                await _patientApiService.UpdatePatient(id, patient);
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _patientApiService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _patientApiService.DeletePatient(id);
            return RedirectToAction("Index");
        }
    }

}
