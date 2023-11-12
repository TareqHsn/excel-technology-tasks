using patientInfo.Models;

namespace patientInfo.Repositories.NCD_DetailsRepository
{
    public interface INCD_DetailsRepository
    {
        Task<IEnumerable<NCD_Details>> GetNCD_DetailsAsync();
        Task<NCD_Details> GetNCD_DetailsByIdAsync(int id);
        Task<NCD_Details> AddNCD_DetailsAsync(NCD_Details ncd_Details);
        Task<bool> UpdateNCD_DetailsAsync(int id, NCD_Details ncd_Details);
        Task<bool> DeleteNCD_DetailsAsync(int id);
    }
}
