using JobDealsAPI.Models;
using JobDealsAPI.Models.Dtos;
using JobDealsAPI.Repositories.Interfaces;
using JobDealsAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobDealsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsapp")]
    public class SoftSkillController : ControllerBase
    {
        private readonly ISoftSkillRepository _softSkillRepository;

        public SoftSkillController(ISoftSkillRepository softSkillRepository)
        {
            _softSkillRepository = softSkillRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftSkillDTO>>> GetAllSoftSkills()
        {
            var softSkills = await _softSkillRepository.GetAllSoftSkills();
            var softSkillDTOs = softSkills.Select(s => new SoftSkillDTO
            {
                Id = s.Id,
                SoftSkillName = s.SoftSkillName
            }).ToList();

            return Ok(softSkillDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SoftSkillDTO>> GetSoftSkillById(int id)
        {
            var softSkill = await _softSkillRepository.GetSoftSkillById(id);
            if (softSkill == null)
            {
                return NotFound();
            }

            var softSkillDTO = new SoftSkillDTO
            {
                Id = softSkill.Id,
                SoftSkillName = softSkill.SoftSkillName
            };

            return Ok(softSkillDTO);
        }

        [HttpPost]
        public async Task<ActionResult<SoftSkillDTO>> AddSoftSkill([FromBody] SoftSkillModel softSkill)
        {
            if (softSkill == null || softSkill.ProfileId == 0)
            {
                return BadRequest(new { error = "ProfileId is required" });
            }

            var addedSoftSkill = await _softSkillRepository.AddSoftSkill(softSkill);

            var softSkillDTO = new SoftSkillDTO
            {
                Id = addedSoftSkill.Id,
                SoftSkillName = addedSoftSkill.SoftSkillName
            };

            return CreatedAtAction(nameof(GetSoftSkillById), new { id = softSkillDTO.Id }, softSkillDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSoftSkill(int id, SoftSkillModel softSkill)
        {
            if (id != softSkill.Id)
            {
                return BadRequest();
            }

            await _softSkillRepository.UpdateSoftSkill(softSkill, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftSkill(int id)
        {
            await _softSkillRepository.DeleteSoftSkill(id);
            return NoContent();
        }
    }
}
