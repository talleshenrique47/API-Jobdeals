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
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }


        [HttpGet]
        public async Task<ActionResult <List<TarefaModel>>> SeachAllTarefas()
        {
            List<TarefaModel> tarefa = await _tarefaRepository.SeachAllTarefas();
            return Ok(tarefa);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> SeachById(int id)
        {
            TarefaModel tarefa = await _tarefaRepository.SeachById(id);
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Add([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepository.Add(tarefaModel);
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Update([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepository.Update(tarefaModel, id);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Delete(int id)
        {
            bool delete = await _tarefaRepository.Delete(id);
            return Ok(delete);
        }
    }
}
