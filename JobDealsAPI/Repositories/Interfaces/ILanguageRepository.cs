using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetAllLanguages();
        Task<LanguageModel> GetLanguageById(int id);
        Task<LanguageModel> AddLanguage(LanguageModel language);
        Task<LanguageModel> UpdateLanguage(LanguageModel language, int id);
        Task<bool> DeleteLanguage(int id);
    }
}
