using Microsoft.EntityFrameworkCore;
using patientInfo.Data;
using patientInfo.Models;

namespace patientInfo.Repositories.NCDRepository
{
    public class NCDRepository : INCDRepository
    {
        private readonly AppDbContext _context;

        public NCDRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NCD>> GetNCDsAsync()
        {
            return await _context.NCDs.ToListAsync();
        }

        public async Task<NCD> GetNCDByIdAsync(int id)
        {
            return await _context.NCDs.FirstOrDefaultAsync(n => n.NCDID == id);
        }

        public async Task<NCD> AddNCDAsync(NCD ncd)
        {
            _context.NCDs.Add(ncd);
            await _context.SaveChangesAsync();
            return ncd;
        }

        public async Task<bool> UpdateNCDAsync(int id, NCD ncd)
        {
            var existingNCD = await _context.NCDs.FirstOrDefaultAsync(n => n.NCDID == id);

            if (existingNCD == null)
            {
                return false;
            }

            existingNCD.NCDName = ncd.NCDName;

            _context.NCDs.Update(existingNCD);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNCDAsync(int id)
        {
            var ncd = await _context.NCDs.FirstOrDefaultAsync(n => n.NCDID == id);

            if (ncd == null)
            {
                return false;
            }

            _context.NCDs.Remove(ncd);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
