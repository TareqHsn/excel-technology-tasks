namespace patientInfo.Models
{
    public class NCD_Details
    {
        public int NCD_DetailsID { get; set; }
        public int PatientID { get; set; }
        public int NCDID { get; set; }

        public Patient Patient { get; set; } 
        public NCD NCD { get; set; } 
    }
}
