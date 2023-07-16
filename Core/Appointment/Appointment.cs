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

        public void CancelAppointment(Appointment appointment  )
        {
            appointment.ApptStatus = "Cancelled";
            appointment.PatientId = null;
            //TODO  Apply(new AppointmentCancelled(  appointmentId));
        }
        public void On(AppointmentCancelled @event)
        {

        }

        public void On(AppointmentCreated @event)
        {
              Id = new AppointmentId(@event.AppointmentId);
              ApptTime = @event.AppointmentTime;

        }
        public static Appointment CreateNewAppointment(string time)
        {
            var appt = new Appointment();
            appt.Apply(new AppointmentCreated(new AppointmentId().ToString(),
                time));

            return appt;
        }
    }
}