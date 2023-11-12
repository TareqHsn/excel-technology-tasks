using patientInfo.Models;

namespace patientInfo.Repositories.AllergiesDetailsRepository
{
    public interface IAllergies_DetailsRepository
    {
        Task<IEnumerable<Allergies_Details>> GetAllergies_DetailsAsync();
        Task<Allergies_Details> GetAllergies_DetailsByIdAsync(int id);
        Task<Allergies_Details> AddAllergies_DetailsAsync(Allergies_Details allergies_Details);
        Task<bool> UpdateAllergies_DetailsAsync(int id, Allergies_Details allergies_Details);
        Task<bool> DeleteAllergies_DetailsAsync(int id);
    }
}
