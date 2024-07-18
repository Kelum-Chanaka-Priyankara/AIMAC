using System.ComponentModel.DataAnnotations;

namespace MedicalAssistant_API.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public string? Purpose { get; set; }
        public string? Notes { get; set; }

    }
}
