namespace Scheduling.API.Model
{
    public class AppointmentDto
    {
        public string AppointmentId {get;  set; }
        public string ApptTime { get;  set; }
        public string PatientId { get;  set; }
        public string UpdatedBy { get;  set; }
        public string ApptStatus { get;  set; }
    }
}