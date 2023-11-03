using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> SeachAllTarefas();
        Task<TarefaModel> SeachById(int id);
        Task<TarefaModel> Add(TarefaModel tarefa);
        Task<TarefaModel> Update(TarefaModel tarefa, int id);
        Task<bool> Delete (int id);
    }
}
