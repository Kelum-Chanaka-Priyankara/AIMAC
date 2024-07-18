using System.ComponentModel.DataAnnotations;

namespace MedicalAssistant_API.Models
{
    public class MedicalRecord
    {
        [Key]
        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string? Symptoms { get; set; }
        public string? Diagnosis { get; set; }
        public string? PrescribedMedication { get; set; }
        public string? Notes { get; set; }
    }
}
