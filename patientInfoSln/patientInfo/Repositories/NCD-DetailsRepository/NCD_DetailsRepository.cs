using Microsoft.EntityFrameworkCore;
using patientInfo.Data;
using patientInfo.Models;

namespace patientInfo.Repositories.NCD_DetailsRepository
{
    public class NCD_DetailsRepository : INCD_DetailsRepository
    {
        private readonly AppDbContext _context;

        public NCD_DetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NCD_Details>> GetNCD_DetailsAsync()
        {
            return await _context.NCD_Details
                .Include(nd => nd.Patient)
                .Include(nd => nd.NCD)
                .ToListAsync();
        }

        public async Task<NCD_Details> GetNCD_DetailsByIdAsync(int id)
        {
            return await _context.NCD_Details
                .Include(nd => nd.Patient)
                .Include(nd => nd.NCD)
                .FirstOrDefaultAsync(nd => nd.NCD_DetailsID == id);
        }

        public async Task<NCD_Details> AddNCD_DetailsAsync(NCD_Details ncd_Details)
        {
            _context.NCD_Details.Add(ncd_Details);
            await _context.SaveChangesAsync();
            return ncd_Details;
        }

        public async Task<bool> UpdateNCD_DetailsAsync(int id, NCD_Details ncd_Details)
        {
            var existingNCD_Details = await _context.NCD_Details
                .FirstOrDefaultAsync(nd => nd.NCD_DetailsID == id);

            if (existingNCD_Details == null)
            {
                return false;
            }

            existingNCD_Details.PatientID = ncd_Details.PatientID;
            existingNCD_Details.NCDID = ncd_Details.NCDID;

            _context.NCD_Details.Update(existingNCD_Details);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNCD_DetailsAsync(int id)
        {
            var ncd_Details = await _context.NCD_Details
                .FirstOrDefaultAsync(nd => nd.NCD_DetailsID == id);

            if (ncd_Details == null)
            {
                return false;
            }

            _context.NCD_Details.Remove(ncd_Details);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
