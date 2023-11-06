using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface IDescriptionRepository
    {
        Task<List<DescriptionModel>> SeachAllDescriptions();
        Task<DescriptionModel> SeachById(int id);
        Task<DescriptionModel> Add(DescriptionModel description);
        Task<DescriptionModel> Update(DescriptionModel description, int id);
        Task<bool> Delete (int id);
        
    }
}
