namespace HCAMiniEHR.Models.DTOs
{
    public class AppointmentListDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
