using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using patientInfo.Models;
using patientInfo.Repositories.DiseaseRepository;

namespace patientInfo.Controllers
{
    [Route("api/Diseases")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseRepository _diseaseRepository;

        public DiseasesController(IDiseaseRepository diseaseRepository)
        {
            _diseaseRepository = diseaseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> GetDiseases()
        {
            var diseases = await _diseaseRepository.GetAllDiseases();
            return Ok(diseases);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Disease>> GetDisease(int id)
        {
            var disease = await _diseaseRepository.GetDiseaseById(id);

            if (disease == null)
            {
                return NotFound();
            }

            return Ok(disease);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostDisease(Disease disease)
        {
            var newDiseaseId = await _diseaseRepository.AddDisease(disease);
            //return CreatedAtAction(nameof(GetDisease), new { id = newDiseaseId }, newDiseaseId);
            var newDisease = await _diseaseRepository.GetDiseaseById(newDiseaseId);

            return Ok(newDiseaseId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisease(int id, Disease disease)
        {
            if (id != disease.DiseaseID)
            {
                return BadRequest();
            }

            await _diseaseRepository.UpdateDisease(disease);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisease(int id)
        {
            await _diseaseRepository.DeleteDisease(id);
            return NoContent();
        }
    }
}
