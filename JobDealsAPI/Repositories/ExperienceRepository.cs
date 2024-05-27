using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public ExperienceRepository(JobDealsDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ExperienceModel>> SearchAllExperiences()
        {
            return await _dbContext.Experiences.ToListAsync();
        }

        public async Task<ExperienceModel> SearchById(int id)
        {
            return await _dbContext.Experiences.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ExperienceModel> Add(ExperienceModel experience)
        {
            await _dbContext.Experiences.AddAsync(experience);
            await _dbContext.SaveChangesAsync();
            return experience;
        }

        public async Task<ExperienceModel> Update(ExperienceModel experience, int id)
        {
            ExperienceModel experienceById = await SearchById(id);

            if (experienceById == null)
            {
                throw new Exception($"Experiência profissional para o ID: {id} não foi encontrada no banco de dados.");
            }

            experienceById.JobTitle = experience.JobTitle;
            experienceById.Company = experience.Company;
            experienceById.StartDate = experience.StartDate;
            experienceById.EndDate = experience.EndDate;

            _dbContext.Experiences.Update(experienceById);
            await _dbContext.SaveChangesAsync();

            return experienceById;
        }

        public async Task<bool> Delete(int id)
        {
            var experience = await _dbContext.Experiences.FindAsync(id);
            if (experience == null)
            {
                throw new Exception($"Experiência profissional com o ID {id} não encontrada.");
            }

            _dbContext.Experiences.Remove(experience);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
