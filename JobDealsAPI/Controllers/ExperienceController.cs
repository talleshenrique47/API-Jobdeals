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
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceController(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienceDTO>> GetExperience(int id)
        {
            var experience = await _experienceRepository.SearchById(id);
            if (experience == null)
            {
                return NotFound();
            }

            var experienceDTO = new ExperienceDTO
            {
                Id = experience.Id,
                JobTitle = experience.JobTitle,
                Company = experience.Company,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate
            };

            return Ok(experienceDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ExperienceDTO>> PostExperience([FromBody] ExperienceModel experience)
        {
            if (experience == null || experience.ProfileId == 0)
            {
                return BadRequest(new { error = "ProfileId is required" });
            }

            var addExperience = await _experienceRepository.Add(experience);

            var experienceReturnDto = new ExperienceDTO
            {
                Id = addExperience.Id,
                JobTitle = addExperience.JobTitle,
                Company = addExperience.Company,
                StartDate = addExperience.StartDate,
                EndDate = addExperience.EndDate
            };

            return CreatedAtAction(nameof(GetExperience), new { id = experienceReturnDto.Id }, experienceReturnDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperience(int id, ExperienceModel experience)
        {
            if (id != experience.Id)
            {
                return BadRequest();
            }
            await _experienceRepository.Update(experience, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            await _experienceRepository.Delete(id);
            return NoContent();
        }
    }
}
