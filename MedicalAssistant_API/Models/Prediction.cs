using System.ComponentModel.DataAnnotations;

namespace MedicalAssistant_API.Models
{
    public class Prediction
    {
        [Key]
        public int PredictionID { get; set; }
        public int PatientID { get; set; }
        public DateTime DateGenerated { get; set; }
        public string? PredictedCondition { get; set; }
        public string? RiskLevel { get; set; }
        public string? RecommendedActions { get; set; }
    }
}
