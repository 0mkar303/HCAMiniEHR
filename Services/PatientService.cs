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

        public Task CreateAsync(Patient patient)
        {
            if (patient.DOB > DateTime.Today)
                throw new Exception("DOB cannot be in future");

            return _repo.CreateUsingSPAsync(patient);
        }

        public Task UpdateAsync(Patient patient)
            => _repo.UpdateUsingSPAsync(patient);

        //public Task DeleteAsync(int id)
        //    => _repo.DeleteUsingSPAsync(id);

        public async Task DeleteAsync(int id)
        {
            bool hasPendingWork =
                await _repo.HasPendingAppointmentsOrLabsAsync(id);


            if (hasPendingWork)
                throw new InvalidOperationException(
                    "Cannot deactivate patient. Pending appointments or lab orders exist."
                );

            await _repo.DeleteUsingSPAsync(id);
        }


    }
}
