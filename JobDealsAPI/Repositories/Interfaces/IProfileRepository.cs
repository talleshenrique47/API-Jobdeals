using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        Task<List<ProfileModel>> SeachAllProfile();
        Task<ProfileModel> SeachById(int id);
        Task<ProfileModel> Add(ProfileModel profile);
        Task<ProfileModel> Update(ProfileModel profile, int id);
        Task<bool> Delete(int id);
    }
}
