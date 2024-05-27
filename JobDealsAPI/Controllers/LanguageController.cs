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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageDTO>> GetLanguageById(int id)
        {
            var language = await _languageRepository.GetLanguageById(id);
            if (language == null)
            {
                return NotFound();
            }

            var languageDTO = new LanguageDTO
            {
                Id = language.Id,
                LanguageName = language.LanguageName
            };

            return Ok(languageDTO);
        }

        [HttpPost]
        public async Task<ActionResult<LanguageDTO>> AddLanguage([FromBody] LanguageModel language)
        {
            if (language == null)
            {
                return BadRequest(new { error = "Invalid request body" });
            }

            var addedLanguage = await _languageRepository.AddLanguage(language);

            var languageReturnDto = new LanguageDTO
            {
                Id = addedLanguage.Id,
                LanguageName = addedLanguage.LanguageName
            };

            return CreatedAtAction(nameof(GetLanguageById), new { id = languageReturnDto.Id }, languageReturnDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(int id, LanguageModel language)
        {
            if (id != language.Id)
            {
                return BadRequest();
            }
            await _languageRepository.UpdateLanguage(language, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            await _languageRepository.DeleteLanguage(id);
            return NoContent();
        }
    }
}
