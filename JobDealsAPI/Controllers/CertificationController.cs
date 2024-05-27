using JobDealsAPI.Models.Dtos;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JobDealsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsapp")]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationRepository _certificationRepository;

        public CertificationController(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CertificationDTO>> GetCertification(int id)
        {
            var certification = await _certificationRepository.SearchById(id);
            if (certification == null)
            {
                return NotFound();
            }

            var certificationDTO = new CertificationDTO
            {
                Id = certification.Id,
                CertificationName = certification.CertificationName,
                ObtainedDate = certification.ObtainedDate,
                Institution = certification.Institution
            };

            return Ok(certificationDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CertificationDTO>> PostCertification([FromBody] CertificationModel certification)
        {
            if (certification == null || certification.ProfileId == 0)
            {
                return BadRequest(new { error = "ProfileId is required" });
            }

            var addCertification = await _certificationRepository.Add(certification);

            var certificationReturnDto = new CertificationDTO
            {
                Id = addCertification.Id,
                CertificationName = addCertification.CertificationName,
                ObtainedDate = addCertification.ObtainedDate,
                Institution = addCertification.Institution
            };

            return CreatedAtAction(nameof(GetCertification), new { id = certificationReturnDto.Id }, certificationReturnDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertification(int id, CertificationModel certification)
        {
            if (id != certification.Id)
            {
                return BadRequest();
            }
            await _certificationRepository.Update(certification, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertification(int id)
        {
            await _certificationRepository.Delete(id);
            return NoContent();
        }
    }
}
