using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public ProjectRepository(JobDealsDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjectModel>> SearchAllProjects()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<ProjectModel> SearchById(int id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProjectModel> Add(ProjectModel project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<ProjectModel> Update(ProjectModel project, int id)
        {
            ProjectModel projectById = await SearchById(id);

            if (projectById == null)
            {
                throw new Exception($"Projeto com o ID: {id} não foi encontrado no banco de dados.");
            }

            // Atualizar as propriedades do projeto
            projectById.ProjectName = project.ProjectName; // Adicione outras propriedades aqui, se necessário

            _dbContext.Projects.Update(projectById);
            await _dbContext.SaveChangesAsync();

            return projectById;
        }

        public async Task<bool> Delete(int id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            if (project == null)
            {
                throw new Exception($"Projeto com o ID {id} não encontrado.");
            }

            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
