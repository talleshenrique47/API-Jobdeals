using JobDealsAPI.Models;
using JobDealsAPI.Models.Dtos;
using JobDealsAPI.Repositories;
using JobDealsAPI.Repositories.Interfaces;
using JobDealsAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JobDealsAPI.Controllers
{
    [ApiController]
    [Route("v1")]
    [EnableCors("corsapp")]
    public class LoginController:ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public LoginController(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService; // TokenService é injetado no construtor
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] LoginRequestModel loginRequestModel)
        {
            UserModel user = await _userRepository.GetLogin(loginRequestModel.Email, loginRequestModel.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
            };

            var token = _tokenService.GenerateToken(userDTO);

            return new { user = userDTO, token = token };
        }
    }
}
