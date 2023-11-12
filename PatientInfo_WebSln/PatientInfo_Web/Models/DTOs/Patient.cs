namespace PatientInfo_Web.Models.DTOs
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public int DiseaseID { get; set; }
        public Disease Disease { get; set; }
    }
    public enum EpilepsyStatus
    {
        No = 1,
        Yes = 2,
    }
    public class Disease
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public EpilepsyStatus Epilepsy { get; set; }
    }
}
