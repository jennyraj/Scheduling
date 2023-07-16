using System.Collections.Generic;
using Tacta.EventStore.Domain;

namespace Scheduling.Core.Appointment
{
    public class AppointmentCreated : IEnumerable<IDomainEvent>
    {
        public AppointmentCreated(string toString, string time, string apptId)
        {
            throw new System.NotImplementedException();
        }
    }
}