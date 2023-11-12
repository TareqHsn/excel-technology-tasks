namespace patientInfo.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }     
        public int DiseaseID { get; set; }
        public Disease Disease { get; set; }
    }
}
