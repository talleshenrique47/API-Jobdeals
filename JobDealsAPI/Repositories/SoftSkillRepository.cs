using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class SoftSkillRepository : ISoftSkillRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public SoftSkillRepository(JobDealsDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SoftSkillModel>> GetAllSoftSkills()
        {
            return await _dbContext.SoftSkills.ToListAsync();
        }

        public async Task<SoftSkillModel> GetSoftSkillById(int id)
        {
            return await _dbContext.SoftSkills.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SoftSkillModel> AddSoftSkill(SoftSkillModel skill)
        {
            await _dbContext.SoftSkills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();
            return skill;
        }

        public async Task<SoftSkillModel> UpdateSoftSkill(SoftSkillModel skill, int id)
        {
            SoftSkillModel skillById = await GetSoftSkillById(id);

            if (skillById == null)
            {
                throw new Exception($"SoftSkill com o ID: {id} não foi encontrado no banco de dados.");
            }

            skillById.SoftSkillName = skill.SoftSkillName;

            _dbContext.SoftSkills.Update(skillById);
            await _dbContext.SaveChangesAsync();

            return skillById;
        }

        public async Task<bool> DeleteSoftSkill(int id)
        {
            var skill = await _dbContext.SoftSkills.FindAsync(id);
            if (skill == null)
            {
                throw new Exception($"SoftSkill com o ID {id} não encontrado.");
            }

            _dbContext.SoftSkills.Remove(skill);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
