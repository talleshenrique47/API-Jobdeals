using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JobDealsDBContex _dbContext;
        public UserRepository(JobDealsDBContex jobDealsDBContext)
        {
            _dbContext = jobDealsDBContext;
        }

        public async Task<UserModel> SeachById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> SeachAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await SeachById(id);

            if(userById == null)
            {
                throw new Exception($"Usuário para o ID: {id} Não foi encontrado no banco de dados.");
            }

            userById.FirstName = user.FirstName;
            userById.LastName = user.LastName;
            userById.Email = user.Email;
            userById.Password = user.Password;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await SeachById(id);

            if (userById == null)
            {
                throw new Exception($"Usuário para o ID: {id} Não foi encontrado no banco de dados.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
