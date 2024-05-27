using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JobDealsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsapp")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProjects()
        {
            var projects = await _projectRepository.SearchAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProject(int id)
        {
            var project = await _projectRepository.SearchById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectModel>> PostProject([FromBody] ProjectModel project)
        {
            if (project == null || project.ProfileId == 0)
            {
                return BadRequest(new { error = "ProfileId is required" });
            }

            var addedProject = await _projectRepository.Add(project);

            return CreatedAtAction(nameof(GetProject), new { id = addedProject.Id }, addedProject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectModel project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }
            await _projectRepository.Update(project, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectRepository.Delete(id);
            return NoContent();
        }
    }
}
