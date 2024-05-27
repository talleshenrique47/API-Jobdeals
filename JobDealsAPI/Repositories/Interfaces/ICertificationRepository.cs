using JobDealsAPI.Models;

namespace JobDealsAPI.Repositories.Interfaces
{
    public interface ICertificationRepository
    {
        Task<List<CertificationModel>> SearchAllCertifications();
        Task<CertificationModel> SearchById(int id);
        Task<CertificationModel> Add(CertificationModel certification);
        Task<CertificationModel> Update(CertificationModel certification, int id);
        Task<bool> Delete(int id);
    }
}
