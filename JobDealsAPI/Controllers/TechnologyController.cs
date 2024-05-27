using JobDealsAPI.Models;
using JobDealsAPI.Models.Dtos;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JobDealsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsapp")]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyController(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TechnologyDTO>> GetTechnologyById(int id)
        {
            var technology = await _technologyRepository.GetTechnologyById(id);
            if (technology == null)
            {
                return NotFound();
            }

            var technologyDTO = new TechnologyDTO
            {
                Id = technology.Id,
                TechnologyName = technology.TechnologyName
            };

            return Ok(technologyDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TechnologyDTO>> AddTechnology([FromBody] TechnologyModel technology)
        {
            if (technology == null)
            {
                return BadRequest(new { error = "Invalid request body" });
            }

            var addedTechnology = await _technologyRepository.AddTechnology(technology);

            var technologyReturnDto = new TechnologyDTO
            {
                Id = addedTechnology.Id,
                TechnologyName = addedTechnology.TechnologyName
            };

            return CreatedAtAction(nameof(GetTechnologyById), new { id = technologyReturnDto.Id }, technologyReturnDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnology(int id, TechnologyModel technology)
        {
            if (id != technology.Id)
            {
                return BadRequest();
            }
            await _technologyRepository.UpdateTechnology(technology, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnology(int id)
        {
            await _technologyRepository.DeleteTechnology(id);
            return NoContent();
        }
    }
}
