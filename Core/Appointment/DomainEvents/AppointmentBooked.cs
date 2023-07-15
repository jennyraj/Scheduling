using Tacta.EventStore.Domain;

namespace Scheduling.Core.Appointment.DomainEvents
{
    public class AppointmentBooked : DomainEvent
    {
        public string AppointmentId { get; }


        public AppointmentBooked(
            string apptTime, string patientId, string updatedBy, string Id) : base(Id.ToString())
        {
        }


    }
}