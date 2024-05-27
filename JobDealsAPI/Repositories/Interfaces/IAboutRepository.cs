using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface IAboutRepository
    {
        Task<List<AboutModel>> SearchAllAbout();
        Task<AboutModel> SearchById(int id);
        Task<AboutModel> Add(AboutModel about);
        Task<AboutModel> Update(AboutModel about, int id);
        Task<bool> Delete(int id);
    }
}
