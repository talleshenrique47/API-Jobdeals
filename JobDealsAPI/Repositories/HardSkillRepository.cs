using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class HardSkillRepository : IHardSkillRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public HardSkillRepository(JobDealsDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HardSkillModel>> GetAllHardSkills()
        {
            return await _dbContext.HardSkills.ToListAsync();
        }

        public async Task<HardSkillModel> GetHardSkillById(int id)
        {
            return await _dbContext.HardSkills.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HardSkillModel> AddHardSkill(HardSkillModel skill)
        {
            await _dbContext.HardSkills.AddAsync(skill);
            await _dbContext.SaveChangesAsync();
            return skill;
        }

        public async Task<HardSkillModel> UpdateHardSkill(HardSkillModel skill, int id)
        {
            HardSkillModel skillById = await GetHardSkillById(id);

            if (skillById == null)
            {
                throw new Exception($"HardSkill com o ID: {id} não foi encontrado no banco de dados.");
            }

            skillById.HardSkillName = skill.HardSkillName;

            _dbContext.HardSkills.Update(skillById);
            await _dbContext.SaveChangesAsync();

            return skillById;
        }

        public async Task<bool> DeleteHardSkill(int id)
        {
            var skill = await _dbContext.HardSkills.FindAsync(id);
            if (skill == null)
            {
                throw new Exception($"HardSkill com o ID {id} não encontrado.");
            }

            _dbContext.HardSkills.Remove(skill);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
