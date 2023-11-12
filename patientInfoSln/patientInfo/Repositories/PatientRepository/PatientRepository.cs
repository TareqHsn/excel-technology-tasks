using Microsoft.EntityFrameworkCore;
using patientInfo.Data;
using patientInfo.Models;

namespace patientInfo.Repositories.PatientRepository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.Include(p => p.Disease).ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.Include(p => p.Disease).FirstOrDefaultAsync(p => p.PatientID == id);
        }

        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<bool> UpdatePatientAsync(int id, Patient patient)
        {
            var existingPatient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientID == id);

            if (existingPatient == null)
            {
                return false;
            }

            existingPatient.Name = patient.Name;
            existingPatient.DiseaseID = patient.DiseaseID;

            _context.Patients.Update(existingPatient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientID == id);

            if (patient == null)
            {
                return false;
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
