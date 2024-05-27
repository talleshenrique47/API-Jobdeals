using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public TechnologyRepository(JobDealsDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TechnologyModel>> GetAllTechnologies()
        {
            return await _dbContext.Technologies.ToListAsync();
        }

        public async Task<TechnologyModel> GetTechnologyById(int id)
        {
            return await _dbContext.Technologies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TechnologyModel> AddTechnology(TechnologyModel technology)
        {
            await _dbContext.Technologies.AddAsync(technology);
            await _dbContext.SaveChangesAsync();
            return technology;
        }

        public async Task<TechnologyModel> UpdateTechnology(TechnologyModel technology, int id)
        {
            var technologyToUpdate = await _dbContext.Technologies.FindAsync(id);

            if (technologyToUpdate == null)
            {
                throw new Exception($"Tecnologia com o ID: {id} não foi encontrada no banco de dados.");
            }

            technologyToUpdate.TechnologyName = technology.TechnologyName;

            _dbContext.Technologies.Update(technologyToUpdate);
            await _dbContext.SaveChangesAsync();

            return technologyToUpdate;
        }

        public async Task<bool> DeleteTechnology(int id)
        {
            var technologyToDelete = await _dbContext.Technologies.FindAsync(id);

            if (technologyToDelete == null)
            {
                throw new Exception($"Tecnologia com o ID: {id} não foi encontrada no banco de dados.");
            }

            _dbContext.Technologies.Remove(technologyToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
