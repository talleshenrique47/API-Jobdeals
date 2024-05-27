using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<ProjectModel>> SearchAllProjects();
        Task<ProjectModel> SearchById(int id);
        Task<ProjectModel> Add(ProjectModel project);
        Task<ProjectModel> Update(ProjectModel project, int id);
        Task<bool> Delete(int id);
    }
}
