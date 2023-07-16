using Tacta.EventStore.Domain;

namespace Scheduling.Core.Appointment
{
    public class AppointmentCreated : DomainEvent
    {
        public string AppointmentId { get; }
        public string AppointmentTime { get; }
        public string PatientId { get; }

        public AppointmentCreated(string appointmentId, string patientId, string time) : base(appointmentId)
        {
            AppointmentId = appointmentId;
            AppointmentTime = time;
            PatientId = patientId;
        }
    }
}