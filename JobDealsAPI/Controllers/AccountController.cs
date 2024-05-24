using JobDealsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobDealsAPI.Controllers
{
    [ApiController]
    [EnableCors("corsapp")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Autenticado - {User.Identity.Name}";

        [HttpGet]
        [Route("candidate")]
        [Authorize(Roles = "candidate, admin")]
        public string Candidate() => "Candidato";

        [HttpGet]
        [Route("company")]
        [Authorize(Roles = "company, admin")]
        public string Company() => "Empresa";

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public string Admin() => "Administrador";
    }
}
