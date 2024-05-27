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
    public class AcademicFormationController : ControllerBase
    {
        private readonly IAcademicFormationRepository _academicFormationRepository;

        public AcademicFormationController(IAcademicFormationRepository academicFormationRepository)
        {
            _academicFormationRepository = academicFormationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicFormationDTO>>> GetAcademicFormations()
        {
            var academicFormations = await _academicFormationRepository.SearchAllAcademicFormations();
            var academicFormationDTOs = academicFormations.Select(a => new AcademicFormationDTO
            {
                Id = a.Id,
                Institution = a.Institution,
                Course = a.Course,
                CompletionDate = a.CompletionDate
            }).ToList();

            return Ok(academicFormationDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicFormationDTO>> GetAcademicFormation(int id)
        {
            var academicFormation = await _academicFormationRepository.SearchById(id);
            if (academicFormation == null)
            {
                return NotFound();
            }

            var academicFormationDTO = new AcademicFormationDTO
            {
                Id = academicFormation.Id,
                Institution = academicFormation.Institution,
                Course = academicFormation.Course,
                CompletionDate = academicFormation.CompletionDate
            };

            return Ok(academicFormationDTO);
        }

        [HttpPost]
        public async Task<ActionResult<AcademicFormationDTO>> PostAcademicFormation([FromBody] AcademicFormationModel academicFormation)
        {
            if (academicFormation == null || academicFormation.ProfileId == 0)
            {
                return BadRequest(new { error = "ProfileId is required" });
            }

            var addedAcademicFormation = await _academicFormationRepository.Add(academicFormation);

            var academicFormationDTO = new AcademicFormationDTO
            {
                Id = addedAcademicFormation.Id,
                Institution = addedAcademicFormation.Institution,
                Course = addedAcademicFormation.Course,
                CompletionDate = addedAcademicFormation.CompletionDate
            };

            return CreatedAtAction(nameof(GetAcademicFormation), new { id = academicFormationDTO.Id }, academicFormationDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicFormation(int id, AcademicFormationModel academicFormation)
        {
            if (id != academicFormation.Id)
            {
                return BadRequest();
            }
            await _academicFormationRepository.Update(academicFormation, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicFormation(int id)
        {
            await _academicFormationRepository.Delete(id);
            return NoContent();
        }
    }
}
