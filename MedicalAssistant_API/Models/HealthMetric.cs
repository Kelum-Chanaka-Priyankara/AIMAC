using System.ComponentModel.DataAnnotations;

namespace MedicalAssistant_API.Models
{
    public class HealthMetric
    {
        [Key]
        public int MetricID { get; set; }
        public int PatientID { get; set; }
        public DateTime DateRecorded { get; set; }
        public int Age { get; set; }
        public Boolean Sex { get; set; }
        public int ChestPainType { get; set; }
        public Decimal BloodPressure { get; set; }
        public Decimal Cholesterol { get; set; }
        public Boolean FBS_Over120 { get; set; }
        public int EKG { get; set; }
        public int HeartRate { get; set; }
        public Boolean ExerciseAngina { get; set; }
        public Decimal STDepression { get; set; }
        public int SlopeOfST { get; set; }
        public int NumberOfVesselsFluro { get; set; }
        public int Thallium { get; set; }
        public Boolean HeartDisease { get; set; }
    }
}
