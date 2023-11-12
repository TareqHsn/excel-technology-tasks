using Microsoft.EntityFrameworkCore;
using patientInfo.Data;
using patientInfo.Models;

namespace patientInfo.Repositories.DiseaseRepository
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly AppDbContext _context; 

        public DiseaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Disease>> GetAllDiseases()
        {
            return await _context.Diseases.ToListAsync();
        }

        public async Task<Disease> GetDiseaseById(int diseaseId)
        {
            return await _context.Diseases.FindAsync(diseaseId);
        }

        public async Task<int> AddDisease(Disease disease)
        {
            _context.Diseases.Add(disease);
            await _context.SaveChangesAsync();
            return disease.DiseaseID;
        }

        public async Task UpdateDisease(Disease disease)
        {
            _context.Entry(disease).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDisease(int diseaseId)
        {
            var disease = await _context.Diseases.FindAsync(diseaseId);
            if (disease != null)
            {
                _context.Diseases.Remove(disease);
                await _context.SaveChangesAsync();
            }
        }
    }
}
