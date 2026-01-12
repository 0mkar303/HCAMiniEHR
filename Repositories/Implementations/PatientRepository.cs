using HCAMiniEHR.Data;
using HCAMiniEHR.Models;
using HCAMiniEHR.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Repositories.Implementations
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .Where(p => p.Status == "Active")
                .ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task CreateUsingSPAsync(Patient p)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC Healthcare.CreatePatient 
                  @FullName={0}, @DOB={1}, @Gender={2},
                  @MobileNumber={3}, @Email={4},
                  @BloodGroup={5}, @EmergencyContact={6}",
                p.FullName, p.DOB, p.Gender,
                p.MobileNumber, p.Email,
                p.BloodGroup, p.EmergencyContact);
        }

        public async Task UpdateUsingSPAsync(Patient p)
        {
            await _context.Database.ExecuteSqlRawAsync(
                @"EXEC Healthcare.UpdatePatient
                  @PatientId={0}, @FullName={1}, @DOB={2},
                  @Gender={3}, @MobileNumber={4}, @Email={5},
                  @BloodGroup={6}, @EmergencyContact={7}",
                p.PatientId, p.FullName, p.DOB,
                p.Gender, p.MobileNumber, p.Email,
                p.BloodGroup, p.EmergencyContact);
        }

        public async Task DeleteUsingSPAsync(int patientId)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC Healthcare.DeletePatient @PatientId={0}",
                patientId);
        }
    }
}
