using HCAMiniEHR.Models;

namespace HCAMiniEHR.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);

        Task CreateUsingSPAsync(Patient patient);
        Task UpdateUsingSPAsync(Patient patient);
        Task DeleteUsingSPAsync(int patientId);
    }
}
