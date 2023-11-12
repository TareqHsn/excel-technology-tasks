using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using patientInfo.Models;
using patientInfo.Repositories.NCDRepository;

namespace patientInfo.Controllers
{
    [ApiController]
    [Route("api/NCD")]
    public class NCDController : ControllerBase
    {
        private readonly INCDRepository _ncdRepository;

        public NCDController(INCDRepository ncdRepository)
        {
            _ncdRepository = ncdRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetNCDs()
        {
            var ncds = await _ncdRepository.GetNCDsAsync();
            return Ok(ncds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNCDById(int id)
        {
            var ncd = await _ncdRepository.GetNCDByIdAsync(id);

            if (ncd == null)
            {
                return NotFound();
            }

            return Ok(ncd);
        }

        [HttpPost]
        public async Task<IActionResult> AddNCD([FromBody] NCD ncd)
        {
            var addedNCD = await _ncdRepository.AddNCDAsync(ncd);
            return CreatedAtAction(nameof(GetNCDById), new { id = addedNCD.NCDID }, addedNCD);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNCD(int id, [FromBody] NCD ncd)
        {
            var result = await _ncdRepository.UpdateNCDAsync(id, ncd);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCD(int id)
        {
            var result = await _ncdRepository.DeleteNCDAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
