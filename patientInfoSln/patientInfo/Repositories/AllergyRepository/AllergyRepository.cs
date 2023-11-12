using Microsoft.EntityFrameworkCore;
using patientInfo.Data;
using patientInfo.Models;

namespace patientInfo.Repositories.AllergyRepository
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly AppDbContext _context;

        public AllergyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Allergy>> GetAllergiesAsync()
        {
            return await _context.Allergies.ToListAsync();
        }

        public async Task<Allergy> GetAllergyByIdAsync(int id)
        {
            return await _context.Allergies.FirstOrDefaultAsync(a => a.AllergyID == id);
        }

        public async Task<Allergy> AddAllergyAsync(Allergy allergy)
        {
            _context.Allergies.Add(allergy);
            await _context.SaveChangesAsync();
            return allergy;
        }

        public async Task<bool> UpdateAllergyAsync(int id, Allergy allergy)
        {
            var existingAllergy = await _context.Allergies.FirstOrDefaultAsync(a => a.AllergyID == id);

            if (existingAllergy == null)
            {
                return false;
            }

            existingAllergy.AllergiesName = allergy.AllergiesName;

            _context.Allergies.Update(existingAllergy);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAllergyAsync(int id)
        {
            var allergy = await _context.Allergies.FirstOrDefaultAsync(a => a.AllergyID == id);

            if (allergy == null)
            {
                return false;
            }

            _context.Allergies.Remove(allergy);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
