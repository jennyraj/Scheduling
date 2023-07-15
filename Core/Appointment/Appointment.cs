using System.Collections.Generic;
using Scheduling.Core.Appointment.DomainEvents;
using Tacta.EventStore.Domain;

namespace Scheduling.Core.Appointment
{
    public class Appointment: AggregateRoot<AppointmentId>
    {
        public override AppointmentId Id { get; protected set; }
        public string ApptTime { get; private set; }
        public string PatientId { get; private set; }
        public string UpdatedBy { get; private set; }
        public string ApptStatus { get; private set; }

        public Appointment(IEnumerable<IDomainEvent> events) : base(events)
        {
        }

        private Appointment()
        {
            
        }

        public void BookAppointment(string apptTime,string patientId, string updatedBy )
        {
            Apply(new AppointmentBooked(apptTime,patientId,updatedBy, Id.ToString()));
        }

        public void On(AppointmentBooked  @event)
        {


        }

        public void CancelAppointment(string apptTime,string patientId, string updatedBy )
        {
            Apply(new AppointmentCancelled(apptTime,patientId,updatedBy, Id.ToString()));
        }
        public void On(AppointmentCancelled @event)
        {

        }
    }
}