using patientInfo.Models;

namespace patientInfo.Repositories.PatientRepository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task<Patient> AddPatientAsync(Patient patient);
        Task<bool> UpdatePatientAsync(int id, Patient patient);
        Task<bool> DeletePatientAsync(int id);
    }
}
