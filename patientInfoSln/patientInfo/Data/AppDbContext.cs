using Microsoft.EntityFrameworkCore;
using patientInfo.Models;

namespace patientInfo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
      
        public DbSet<Disease> Diseases { get; set; }

        
        public DbSet<Patient> Patients { get; set; }

        
        public DbSet<NCD> NCDs { get; set; }

        
        public DbSet<Allergy> Allergies { get; set; }

        public DbSet<NCD_Details> NCD_Details { get; set; }

        public DbSet<Allergies_Details> Allergies_Details { get; set; }

    }
}
