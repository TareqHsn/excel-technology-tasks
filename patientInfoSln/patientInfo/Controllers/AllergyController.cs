using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using patientInfo.Models;
using patientInfo.Repositories.AllergyRepository;

namespace patientInfo.Controllers
{
    [ApiController]
    [Route("api/Allergy")]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyRepository _allergyRepository;

        public AllergyController(IAllergyRepository allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllergies()
        {
            var allergies = await _allergyRepository.GetAllergiesAsync();
            return Ok(allergies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllergyById(int id)
        {
            var allergy = await _allergyRepository.GetAllergyByIdAsync(id);

            if (allergy == null)
            {
                return NotFound();
            }

            return Ok(allergy);
        }

        [HttpPost]
        public async Task<IActionResult> AddAllergy([FromBody] Allergy allergy)
        {
            var addedAllergy = await _allergyRepository.AddAllergyAsync(allergy);
            return CreatedAtAction(nameof(GetAllergyById), new { id = addedAllergy.AllergyID }, addedAllergy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllergy(int id, [FromBody] Allergy allergy)
        {
            var result = await _allergyRepository.UpdateAllergyAsync(id, allergy);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergy(int id)
        {
            var result = await _allergyRepository.DeleteAllergyAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
