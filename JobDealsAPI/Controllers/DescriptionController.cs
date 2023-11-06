using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobDealsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("corsapp")]
    public class DescriptionController : ControllerBase
    {
        private readonly IDescriptionRepository _descriptionRepository;
        public DescriptionController(IDescriptionRepository descriptionRepository)
        {
            _descriptionRepository = descriptionRepository;
        }


        [HttpGet]
        public async Task<ActionResult <List<DescriptionModel>>> SeachAllDescriptions()
        {
            List<DescriptionModel> description = await _descriptionRepository.SeachAllDescriptions();
            return Ok(description);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DescriptionModel>> SeachById(int id)
        {
            DescriptionModel description = await _descriptionRepository.SeachById(id);
            return Ok(description);
        }

        [HttpPost]
        public async Task<ActionResult<DescriptionModel>> Add([FromBody] DescriptionModel descriptionModel)
        {
            DescriptionModel description = await _descriptionRepository.Add(descriptionModel);
            return Ok(description);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DescriptionModel>> Update([FromBody] DescriptionModel descriptionModel, int id)
        {
            descriptionModel.Id = id;
            DescriptionModel description = await _descriptionRepository.Update(descriptionModel, id);
            return Ok(description);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DescriptionModel>> Delete(int id)
        {
            bool delete = await _descriptionRepository.Delete(id);
            return Ok(delete);
        }
    }
}
