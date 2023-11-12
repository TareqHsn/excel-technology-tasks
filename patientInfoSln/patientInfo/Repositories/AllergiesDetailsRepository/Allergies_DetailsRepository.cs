using Microsoft.EntityFrameworkCore;
using patientInfo.Data;
using patientInfo.Models;

namespace patientInfo.Repositories.AllergiesDetailsRepository
{
    public class Allergies_DetailsRepository : IAllergies_DetailsRepository
    {
        private readonly AppDbContext _context;

        public Allergies_DetailsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Allergies_Details>> GetAllergies_DetailsAsync()
        {
            return await _context.Allergies_Details
                .Include(ad => ad.Patient)
                .Include(ad => ad.Allergy)
                .ToListAsync();
        }

        public async Task<Allergies_Details> GetAllergies_DetailsByIdAsync(int id)
        {
            return await _context.Allergies_Details
                .Include(ad => ad.Patient)
                .Include(ad => ad.Allergy)
                .FirstOrDefaultAsync(ad => ad.Allergies_DetailsID == id);
        }

        public async Task<Allergies_Details> AddAllergies_DetailsAsync(Allergies_Details allergies_Details)
        {
            _context.Allergies_Details.Add(allergies_Details);
            await _context.SaveChangesAsync();
            return allergies_Details;
        }

        public async Task<bool> UpdateAllergies_DetailsAsync(int id, Allergies_Details allergies_Details)
        {
            var existingAllergies_Details = await _context.Allergies_Details
                .FirstOrDefaultAsync(ad => ad.Allergies_DetailsID == id);

            if (existingAllergies_Details == null)
            {
                return false;
            }

            existingAllergies_Details.PatientID = allergies_Details.PatientID;
            existingAllergies_Details.AllergiesID = allergies_Details.AllergiesID;

            _context.Allergies_Details.Update(existingAllergies_Details);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAllergies_DetailsAsync(int id)
        {
            var allergies_Details = await _context.Allergies_Details
                .FirstOrDefaultAsync(ad => ad.Allergies_DetailsID == id);

            if (allergies_Details == null)
            {
                return false;
            }

            _context.Allergies_Details.Remove(allergies_Details);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
