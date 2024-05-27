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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public UserController(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }


        [HttpGet]
        public async Task<ActionResult <List<UserModel>>> SeachAllUsers()
        {
            List<UserModel> users = await _userRepository.SeachAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> SeachById(int id)
        {
            var user = await _userRepository.GetUserWithDetails(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Profile = user.Profile != null ? new ProfileDTO
                {
                    Id = user.Profile.Id,
                    PhotoPath = user.Profile.PhotoPath,
                    UserName = user.Profile.UserName,
                    Title = user.Profile.Title,
                    StatusDescription = user.Profile.StatusDescription,
                    PhoneNumber = user.Profile.PhoneNumber,
                    UserEmail = user.Profile.UserEmail,
                    Github = user.Profile.Github,
                    About = user.Profile.About != null ? new AboutDTO
                    {
                        Id = user.Profile.About.Id,
                        Description = user.Profile.About.Description
                    } : null,
                    Experiences = user.Profile.Experiences != null ? user.Profile.Experiences.Select(e => new ExperienceDTO
                    {
                        Id = e.Id,
                        JobTitle = e.JobTitle,
                        Company = e.Company,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate
                    }).ToList() : new List<ExperienceDTO>()
                } : null
            };

            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel userModel)
        {
            try
            {
                UserModel user = await _userRepository.Add(userModel);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao criar o usuário: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.Update(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            bool delete = await _userRepository.Delete(id);
            return Ok(delete);
        }
    }
}
