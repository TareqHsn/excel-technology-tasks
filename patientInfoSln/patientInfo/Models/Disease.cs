namespace patientInfo.Models
{
    public enum EpilepsyStatus
    {
        No=1,
        Yes=2,
    }
    public class Disease
    {
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public EpilepsyStatus Epilepsy { get; set; }
    }
}
