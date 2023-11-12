using System.ComponentModel.DataAnnotations;

namespace patientInfo.Models
{
    public class Allergies_Details
    {
        
        public int Allergies_DetailsID { get; set; }
        public int PatientID { get; set; }
        public int AllergiesID { get; set; }
        public Patient Patient { get; set; } 
        public Allergy Allergy { get; set; }
    }
}
