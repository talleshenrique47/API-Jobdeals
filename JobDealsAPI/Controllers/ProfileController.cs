using JobDealsAPI.Models;
using JobDealsAPI.Models.Dtos;
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
        public async Task<ActionResult<ProfileDTO>> PostProfile([FromQuery] int userId, [FromBody] ProfileModel profile)
        {
            if (userId != 0)
            {
                // Recuperar o usuário com o ID fornecido
                var user = await _userRepository.SeachById(userId);

                if (user == null)
                {
                    return NotFound("Usuário não encontrado");
                }

                // Preencher automaticamente as informações do usuário no perfil
                profile.UserId = user.Id;
                profile.UserEmail = user.Email;

                var addProfile = await _profileRepository.Add(profile);

                // Criar o DTO de retorno
                var profileReturnDto = new ProfileDTO
                {
                    Id = addProfile.Id,
                    PhotoPath = addProfile.PhotoPath,
                    UserName = addProfile.UserName,
                    Title = addProfile.Title,
                    StatusDescription = addProfile.StatusDescription,
                    PhoneNumber = addProfile.PhoneNumber,
                    UserEmail = addProfile.UserEmail,
                    Github = addProfile.Github
                };

                // Retornar o perfil recém-criado usando DTO
                return CreatedAtAction(nameof(GetProfile), new { id = profileReturnDto.Id }, profileReturnDto);
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