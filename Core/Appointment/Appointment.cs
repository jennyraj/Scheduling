using System.Collections.Generic;
using Scheduling.Core.Appointment.DomainEvents;
using Tacta.EventStore.Domain;

namespace Scheduling.Core.Appointment
{
    public class Appointment : AggregateRoot<AppointmentId>
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

        public void CancelAppointment(Appointment appointment, string updatedBy)
        {
            appointment.ApptStatus = Core.Appointment.ApptStatus.Cancelled;
            appointment.PatientId = null;
            appointment.UpdatedBy = updatedBy;
            Apply(new AppointmentCancelled(appointment.UpdatedBy, appointment.ApptStatus, appointment.PatientId
                , Id.ToString()));
        }

        public void On(AppointmentCancelled @event)
        {
            ApptStatus = @event.ApptStatus;
            PatientId = @event.PatientId;
            UpdatedBy = @event.UpdatedBy;
        }

        public void On(AppointmentCreated @event)
        {
            Id = new AppointmentId(@event.AppointmentId);
            ApptTime = @event.AppointmentTime;
            PatientId = @event.PatientId;
        }

        public static Appointment CreateNewAppointment(string time, string patientId, string lastUpdatedBy)
        {
            var appt = new Appointment
            {
                ApptTime = time
                , PatientId = patientId
                , ApptStatus = Core.Appointment.ApptStatus.Scheduled
                , UpdatedBy = lastUpdatedBy
            };

            appt.Apply(new AppointmentCreated(new AppointmentId().ToString(),
                patientId, time));

            return appt;
        }
    }
}