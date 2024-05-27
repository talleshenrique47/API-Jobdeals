using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class AcademicFormationRepository : IAcademicFormationRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public AcademicFormationRepository(JobDealsDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AcademicFormationModel>> SearchAllAcademicFormations()
        {
            return await _dbContext.AcademicFormations.ToListAsync();
        }

        public async Task<AcademicFormationModel> SearchById(int id)
        {
            return await _dbContext.AcademicFormations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AcademicFormationModel> Add(AcademicFormationModel academicFormation)
        {
            await _dbContext.AcademicFormations.AddAsync(academicFormation);
            await _dbContext.SaveChangesAsync();
            return academicFormation;
        }

        public async Task<AcademicFormationModel> Update(AcademicFormationModel academicFormation, int id)
        {
            var academicFormationById = await SearchById(id);
            if (academicFormationById == null)
            {
                throw new Exception($"Formação Acadêmica para o ID: {id} não foi encontrada no banco de dados.");
            }

            academicFormationById.Institution = academicFormation.Institution;
            academicFormationById.Course = academicFormation.Course;
            academicFormationById.CompletionDate = academicFormation.CompletionDate;

            _dbContext.AcademicFormations.Update(academicFormationById);
            await _dbContext.SaveChangesAsync();

            return academicFormationById;
        }

        public async Task<bool> Delete(int id)
        {
            var academicFormation = await _dbContext.AcademicFormations.FindAsync(id);
            if (academicFormation == null)
            {
                throw new Exception($"Formação Acadêmica com o ID {id} não encontrada.");
            }

            _dbContext.AcademicFormations.Remove(academicFormation);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
