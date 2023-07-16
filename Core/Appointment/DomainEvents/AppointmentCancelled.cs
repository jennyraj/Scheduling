using Tacta.EventStore.Domain;

namespace Scheduling.Core.Appointment.DomainEvents
{
    public class AppointmentCancelled : DomainEvent
    {
        public string UpdatedBy { get; }
        public string ApptStatus { get; }
        public string PatientId { get; }


        public AppointmentCancelled(
            string updatedBy, string apptStatus, string patientId, string Id) : base(Id)
        {
            UpdatedBy = updatedBy;
            ApptStatus = apptStatus;
            PatientId = patientId;
        }
    }
}