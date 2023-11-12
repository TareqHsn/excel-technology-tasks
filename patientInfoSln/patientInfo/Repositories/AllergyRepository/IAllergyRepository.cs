using patientInfo.Models;

namespace patientInfo.Repositories.AllergyRepository
{
    public interface IAllergyRepository
    {
        Task<IEnumerable<Allergy>> GetAllergiesAsync();
        Task<Allergy> GetAllergyByIdAsync(int id);
        Task<Allergy> AddAllergyAsync(Allergy allergy);
        Task<bool> UpdateAllergyAsync(int id, Allergy allergy);
        Task<bool> DeleteAllergyAsync(int id);
    }
}
