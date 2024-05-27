using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface ISoftSkillRepository
    {
        Task<List<SoftSkillModel>> GetAllSoftSkills();
        Task<SoftSkillModel> GetSoftSkillById(int id);
        Task<SoftSkillModel> AddSoftSkill(SoftSkillModel skill);
        Task<SoftSkillModel> UpdateSoftSkill(SoftSkillModel skill, int id);
        Task<bool> DeleteSoftSkill(int id);
    }
}
