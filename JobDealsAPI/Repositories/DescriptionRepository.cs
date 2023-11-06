using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class DescriptionRepository : IDescriptionRepository
    {
        private readonly JobDealsDBContex _dbContext;
        public DescriptionRepository(JobDealsDBContex jobDealsDBContext)
        {
            _dbContext = jobDealsDBContext;
        }

        public async Task<DescriptionModel> SeachById(int id)
        {
            return await _dbContext.Description.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DescriptionModel>> SeachAllDescriptions()
        {
            return await _dbContext.Description
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<DescriptionModel> Add(DescriptionModel description)
        {
            await _dbContext.Description.AddAsync(description);
            await _dbContext.SaveChangesAsync();
            return description;
        }

        public async Task<DescriptionModel> Update(DescriptionModel description, int id)
        {
            DescriptionModel descriptionById = await SeachById(id);

            if(descriptionById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} Não foi encontrado no banco de dados.");
            }

            descriptionById.Name = description.Name;
            descriptionById.Description = description.Description;
            descriptionById.Status = description.Status;
            descriptionById.UserId = description.UserId;

            _dbContext.Description.Update(descriptionById);
            await _dbContext.SaveChangesAsync();

            return descriptionById;
        }

        public async Task<bool> Delete(int id)
        {
            DescriptionModel descriptionById = await SeachById(id);

            if (descriptionById == null)
            {
                throw new Exception($"Tarefa para o ID: {id} Não foi encontrado no banco de dados.");
            }

            _dbContext.Description.Remove(descriptionById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
