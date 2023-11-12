using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using patientInfo.Models;
using patientInfo.Repositories.NCD_DetailsRepository;

namespace patientInfo.Controllers
{
    [ApiController]
    [Route("api/NCD_Details")]
    public class NCD_DetailsController : ControllerBase
    {
        private readonly INCD_DetailsRepository _ncd_DetailsRepository;

        public NCD_DetailsController(INCD_DetailsRepository ncd_DetailsRepository)
        {
            _ncd_DetailsRepository = ncd_DetailsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetNCD_Details()
        {
            var ncd_Details = await _ncd_DetailsRepository.GetNCD_DetailsAsync();
            return Ok(ncd_Details);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNCD_DetailsById(int id)
        {
            var ncd_Details = await _ncd_DetailsRepository.GetNCD_DetailsByIdAsync(id);

            if (ncd_Details == null)
            {
                return NotFound();
            }

            return Ok(ncd_Details);
        }

        [HttpPost]
        public async Task<IActionResult> AddNCD_Details([FromBody] NCD_Details ncd_Details)
        {
            var addedNCD_Details = await _ncd_DetailsRepository.AddNCD_DetailsAsync(ncd_Details);
            return CreatedAtAction(nameof(GetNCD_DetailsById), new { id = addedNCD_Details.NCD_DetailsID }, addedNCD_Details);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNCD_Details(int id, [FromBody] NCD_Details ncd_Details)
        {
            var result = await _ncd_DetailsRepository.UpdateNCD_DetailsAsync(id, ncd_Details);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCD_Details(int id)
        {
            var result = await _ncd_DetailsRepository.DeleteNCD_DetailsAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
