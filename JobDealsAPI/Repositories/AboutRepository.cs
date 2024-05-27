using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public AboutRepository(JobDealsDBContex jobDealsDBContext)
        {
            _dbContext = jobDealsDBContext;
        }

        public async Task<List<AboutModel>> SearchAllAbout()
        {
            return await _dbContext.Abouts.ToListAsync();
        }

        public async Task<AboutModel> SearchById(int id)
        {
            return await _dbContext.Abouts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AboutModel> Add(AboutModel about)
        {
            await _dbContext.Abouts.AddAsync(about);
            await _dbContext.SaveChangesAsync();
            return about;
        }

        public async Task<AboutModel> Update(AboutModel about, int id)
        {
            AboutModel aboutById = await SearchById(id);

            if (aboutById == null)
            {
                throw new Exception($"Descrição para o ID: {id} Não foi encontrado no banco de dados.");
            }

            aboutById.Description = about.Description;

            _dbContext.Abouts.Update(aboutById);
            await _dbContext.SaveChangesAsync();

            return aboutById;
        }

        public async Task<bool> Delete(int id)
        {
            var about = await _dbContext.Abouts.FindAsync(id);
            if (about == null)
            {
                throw new Exception($"Descrição com o ID {id} não encontrado.");
            }

            _dbContext.Abouts.Remove(about);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
