using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface IAcademicFormationRepository
    {
        Task<List<AcademicFormationModel>> SearchAllAcademicFormations();
        Task<AcademicFormationModel> SearchById(int id);
        Task<AcademicFormationModel> Add(AcademicFormationModel academicFormation);
        Task<AcademicFormationModel> Update(AcademicFormationModel academicFormation, int id);
        Task<bool> Delete(int id);
    }
}
