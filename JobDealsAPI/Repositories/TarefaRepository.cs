using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly JobDealsDBContex _dbContext;
        public TarefaRepository(JobDealsDBContex jobDealsDBContext)
        {
            _dbContext = jobDealsDBContext;
        }

        public async Task<TarefaModel> SeachById(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> SeachAllTarefas()
        {
            return await _dbContext.Tarefas
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TarefaModel> Add(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel> Update(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaById = await SeachById(id);

            if(tarefaById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} Não foi encontrado no banco de dados.");
            }

            tarefaById.Name = tarefa.Name;
            tarefaById.Description = tarefa.Description;
            tarefaById.Status = tarefa.Status;
            tarefaById.UserId = tarefa.UserId;

            _dbContext.Tarefas.Update(tarefaById);
            await _dbContext.SaveChangesAsync();

            return tarefaById;
        }

        public async Task<bool> Delete(int id)
        {
            TarefaModel tarefaById = await SeachById(id);

            if (tarefaById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} Não foi encontrado no banco de dados.");
            }

            _dbContext.Tarefas.Remove(tarefaById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
