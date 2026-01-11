using HCAMiniEHR.Models;
using HCAMiniEHR.Repositories.Interfaces;

namespace HCAMiniEHR.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Patient>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<Patient?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task AddAsync(Patient patient)
            => _repo.AddAsync(patient);

        public Task UpdateAsync(Patient patient)
            => _repo.UpdateAsync(patient);

        public Task DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
