using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface ITechnologyRepository
    {
        Task<List<TechnologyModel>> GetAllTechnologies();
        Task<TechnologyModel> GetTechnologyById(int id);
        Task<TechnologyModel> AddTechnology(TechnologyModel technology);
        Task<TechnologyModel> UpdateTechnology(TechnologyModel technology, int id);
        Task<bool> DeleteTechnology(int id);
    }
}
