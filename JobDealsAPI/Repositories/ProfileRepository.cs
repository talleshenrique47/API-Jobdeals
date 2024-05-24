using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobDealsAPI.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public ProfileRepository(JobDealsDBContex jobDealsDBContext)
        {
            _dbContext = jobDealsDBContext;
        }

        public async Task<List<ProfileModel>> SeachAllProfile()
        {
            return await _dbContext.Profiles.ToListAsync();
        }

        public async Task<ProfileModel> SeachById(int id)
        {
            return await _dbContext.Profiles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProfileModel> Add(ProfileModel profile)
        {
            await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();
            return profile;
        }

        public async Task<ProfileModel> Update(ProfileModel profile, int id)
        {
            ProfileModel profileById = await SeachById(id);

            if (profileById == null)
            {
                throw new Exception($"Descrição para o ID: {id} Não foi encontrado no banco de dados.");
            }

            profileById.Title = profile.Title;
            profileById.PhoneNumber = profile.PhoneNumber;
            profileById.Github = profile.Github;

            _dbContext.Profiles.Update(profileById);
            await _dbContext.SaveChangesAsync();

            return profileById;
        }

        public async Task<bool> Delete(int id)
        {
            var profile = await _dbContext.Profiles.FindAsync(id);
            if (profile == null)
            {
                throw new Exception($"Perfil com o ID {id} não encontrado.");
            }

            _dbContext.Profiles.Remove(profile);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
