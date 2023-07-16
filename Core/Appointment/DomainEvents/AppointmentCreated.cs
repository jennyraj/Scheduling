using Tacta.EventStore.Domain;

namespace Scheduling.Core.Appointment
{
    public class AppointmentCreated : DomainEvent
    {
        public string AppointmentId { get; }
        public string AppointmentTime { get; }

        public AppointmentCreated(string appointmentId, string time): base(appointmentId)
        {
            AppointmentId = appointmentId;
            AppointmentTime = time;
        }
    }
}