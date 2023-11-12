using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using patientInfo.Models;
using patientInfo.Repositories.AllergiesDetailsRepository;

namespace patientInfo.Controllers
{
    [ApiController]
    [Route("api/allergies_details")]
    public class Allergies_DetailsController : ControllerBase
    {
        private readonly IAllergies_DetailsRepository _allergies_DetailsRepository;

        public Allergies_DetailsController(IAllergies_DetailsRepository allergies_DetailsRepository)
        {
            _allergies_DetailsRepository = allergies_DetailsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllergies_Details()
        {
            var allergies_Details = await _allergies_DetailsRepository.GetAllergies_DetailsAsync();
            return Ok(allergies_Details);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllergies_DetailsById(int id)
        {
            var allergies_Details = await _allergies_DetailsRepository.GetAllergies_DetailsByIdAsync(id);

            if (allergies_Details == null)
            {
                return NotFound();
            }

            return Ok(allergies_Details);
        }

        [HttpPost]
        public async Task<IActionResult> AddAllergies_Details([FromBody] Allergies_Details allergies_Details)
        {
            var addedAllergies_Details = await _allergies_DetailsRepository.AddAllergies_DetailsAsync(allergies_Details);
            return CreatedAtAction(nameof(GetAllergies_DetailsById), new { id = addedAllergies_Details.Allergies_DetailsID }, addedAllergies_Details);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAllergies_Details(int id, [FromBody] Allergies_Details allergies_Details)
        {
            var result = await _allergies_DetailsRepository.UpdateAllergies_DetailsAsync(id, allergies_Details);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergies_Details(int id)
        {
            var result = await _allergies_DetailsRepository.DeleteAllergies_DetailsAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
