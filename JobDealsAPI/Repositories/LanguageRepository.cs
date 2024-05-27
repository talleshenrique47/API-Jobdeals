using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public LanguageRepository(JobDealsDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LanguageModel>> GetAllLanguages()
        {
            return await _dbContext.Languages.ToListAsync();
        }

        public async Task<LanguageModel> GetLanguageById(int id)
        {
            return await _dbContext.Languages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LanguageModel> AddLanguage(LanguageModel language)
        {
            await _dbContext.Languages.AddAsync(language);
            await _dbContext.SaveChangesAsync();
            return language;
        }

        public async Task<LanguageModel> UpdateLanguage(LanguageModel language, int id)
        {
            var languageToUpdate = await _dbContext.Languages.FindAsync(id);

            if (languageToUpdate == null)
            {
                throw new Exception($"Idioma com o ID: {id} não foi encontrado no banco de dados.");
            }

            languageToUpdate.LanguageName = language.LanguageName;

            _dbContext.Languages.Update(languageToUpdate);
            await _dbContext.SaveChangesAsync();

            return languageToUpdate;
        }

        public async Task<bool> DeleteLanguage(int id)
        {
            var languageToDelete = await _dbContext.Languages.FindAsync(id);

            if (languageToDelete == null)
            {
                throw new Exception($"Idioma com o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Languages.Remove(languageToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
