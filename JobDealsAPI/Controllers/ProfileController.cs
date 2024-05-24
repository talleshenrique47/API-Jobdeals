using JobDealsAPI.Models;
using JobDealsAPI.Repositories;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JobDealsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsapp")]
    public class ProfileController :ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;

        public ProfileController(IProfileRepository profileRepository, IUserRepository userRepository)
        {
            _profileRepository = profileRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileModel>>> GetProfile()
        {
            var profile = await _profileRepository.SeachAllProfile();
            return Ok(profile);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileModel>> GetProfile(int id)
        {
            var profile = await _profileRepository.SeachById(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult<ProfileModel>> PostProfile(int userId, ProfileModel profile)
        {
            if (userId != 0)
            {
                // Recuperar o usuário com o ID fornecido
                var user = await _userRepository.SeachById(userId);

                if (user == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                var addProfile = await _profileRepository.Add(profile);

                // Retornar a descrição do candidato recém-criada
                return CreatedAtAction(nameof(GetProfile), new { id = addProfile.Id }, addProfile);
            }
            else
            {
                // Se o ID do usuário não foi fornecido, retornar um erro
                return BadRequest("ID do usuário não fornecido");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, ProfileModel profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }
            await _profileRepository.Update(profile, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            await _profileRepository.Delete(id);
            return NoContent();
        }
    }
}