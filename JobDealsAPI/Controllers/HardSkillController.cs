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
    public class HardSkillController : ControllerBase
    {
        private readonly IHardSkillRepository _hardSkillRepository;

        public HardSkillController(IHardSkillRepository hardSkillRepository)
        {
            _hardSkillRepository = hardSkillRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HardSkillDTO>>> GetAllHardSkills()
        {
            var hardSkills = await _hardSkillRepository.GetAllHardSkills();
            var hardSkillDTOs = hardSkills.Select(s => new HardSkillDTO
            {
                Id = s.Id,
                HardSkillName = s.HardSkillName
            }).ToList();

            return Ok(hardSkillDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HardSkillDTO>> GetHardSkillById(int id)
        {
            var hardSkill = await _hardSkillRepository.GetHardSkillById(id);
            if (hardSkill == null)
            {
                return NotFound();
            }

            var hardSkillDTO = new HardSkillDTO
            {
                Id = hardSkill.Id,
                HardSkillName = hardSkill.HardSkillName
            };

            return Ok(hardSkillDTO);
        }

        [HttpPost]
        public async Task<ActionResult<HardSkillDTO>> AddHardSkill([FromBody] HardSkillModel hardSkill)
        {
            if (hardSkill == null || hardSkill.ProfileId == 0)
            {
                return BadRequest(new { error = "ProfileId is required" });
            }

            var addedHardSkill = await _hardSkillRepository.AddHardSkill(hardSkill);

            var hardSkillDTO = new HardSkillDTO
            {
                Id = addedHardSkill.Id,
                HardSkillName = addedHardSkill.HardSkillName
            };

            return CreatedAtAction(nameof(GetHardSkillById), new { id = hardSkillDTO.Id }, hardSkillDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHardSkill(int id, HardSkillModel hardSkill)
        {
            if (id != hardSkill.Id)
            {
                return BadRequest();
            }

            await _hardSkillRepository.UpdateHardSkill(hardSkill, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHardSkill(int id)
        {
            await _hardSkillRepository.DeleteHardSkill(id);
            return NoContent();
        }
    }
}
