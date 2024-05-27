using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface IHardSkillRepository
    {
        Task<List<HardSkillModel>> GetAllHardSkills();
        Task<HardSkillModel> GetHardSkillById(int id);
        Task<HardSkillModel> AddHardSkill(HardSkillModel skill);
        Task<HardSkillModel> UpdateHardSkill(HardSkillModel skill, int id);
        Task<bool> DeleteHardSkill(int id);
    }
}
