using Tacta.EventStore.Domain;

namespace Scheduling.Core.Appointment.DomainEvents
{
    public class AppointmentCancelled : DomainEvent
    {

        public AppointmentCancelled(
            string apptTime, string patientId, string updatedBy, string Id) : base(Id)
        {
        }
    }
}