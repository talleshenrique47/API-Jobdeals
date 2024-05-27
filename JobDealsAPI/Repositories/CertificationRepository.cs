using JobDealsAPI.Data;
using JobDealsAPI.Models;
using JobDealsAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobDealsAPI.Repositories
{
    public class CertificationRepository : ICertificationRepository
    {
        private readonly JobDealsDBContex _dbContext;

        public CertificationRepository(JobDealsDBContex dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CertificationModel>> SearchAllCertifications()
        {
            return await _dbContext.Certifications.ToListAsync();
        }

        public async Task<CertificationModel> SearchById(int id)
        {
            return await _dbContext.Certifications.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CertificationModel> Add(CertificationModel certification)
        {
            await _dbContext.Certifications.AddAsync(certification);
            await _dbContext.SaveChangesAsync();
            return certification;
        }

        public async Task<CertificationModel> Update(CertificationModel certification, int id)
        {
            CertificationModel certificationById = await SearchById(id);

            if (certificationById == null)
            {
                throw new Exception($"Certificação para o ID: {id} não foi encontrada no banco de dados.");
            }

            certificationById.CertificationName = certification.CertificationName;
            certificationById.ObtainedDate = certification.ObtainedDate;
            certificationById.Institution = certification.Institution;

            _dbContext.Certifications.Update(certificationById);
            await _dbContext.SaveChangesAsync();

            return certificationById;
        }

        public async Task<bool> Delete(int id)
        {
            var certification = await _dbContext.Certifications.FindAsync(id);
            if (certification == null)
            {
                throw new Exception($"Certificação com o ID {id} não encontrada.");
            }

            _dbContext.Certifications.Remove(certification);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
