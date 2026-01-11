namespace HCAMiniEHR.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }

}
