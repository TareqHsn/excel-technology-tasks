using patientInfo.Models;

namespace patientInfo.Repositories.NCDRepository
{
    public interface INCDRepository
    {
        Task<IEnumerable<NCD>> GetNCDsAsync();
        Task<NCD> GetNCDByIdAsync(int id);
        Task<NCD> AddNCDAsync(NCD ncd);
        Task<bool> UpdateNCDAsync(int id, NCD ncd);
        Task<bool> DeleteNCDAsync(int id);
    }
}
