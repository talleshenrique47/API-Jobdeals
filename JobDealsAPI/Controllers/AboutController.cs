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
    public class AboutController : ControllerBase
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutController(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutModel>>> GetAbout()
        {
            var about = await _aboutRepository.SearchAllAbout();
            return Ok(about);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AboutModel>> GetAbout(int id)
        {
            var about = await _aboutRepository.SearchById(id);
            if (about == null)
            {
                return NotFound();
            }
            return Ok(about);
        }

        [HttpPost]
        public async Task<ActionResult<AboutDTO>> PostAbout([FromBody] AboutModel about)
        {
            var addAbout = await _aboutRepository.Add(about);

            var aboutReturnDto = new AboutDTO
            {
                Id = addAbout.Id,
                Description = addAbout.Description
            };

            return CreatedAtAction(nameof(GetAbout), new { id = aboutReturnDto.Id }, aboutReturnDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbout(int id, AboutModel about)
        {
            if (id != about.Id)
            {
                return BadRequest();
            }
            await _aboutRepository.Update(about, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _aboutRepository.Delete(id);
            return NoContent();
        }
    }
}
