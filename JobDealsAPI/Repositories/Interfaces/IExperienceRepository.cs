using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface IExperienceRepository
    {
        Task<List<ExperienceModel>> SearchAllExperiences();
        Task<ExperienceModel> SearchById(int id);
        Task<ExperienceModel> Add(ExperienceModel experience);
        Task<ExperienceModel> Update(ExperienceModel experience, int id);
        Task<bool> Delete(int id);
    }
}
