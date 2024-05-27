using JobDealsAPI.Models;
using JobDealsAPI.Models.Dtos;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> SeachAllUsers();
        Task<UserModel> SeachById(int id);
        Task<UserModel> GetUserWithDetails(int id);
        Task<UserModel> GetLogin(string email, string password);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
