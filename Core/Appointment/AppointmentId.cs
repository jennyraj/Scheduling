using System;
using Tacta.EventStore.Domain;

namespace Scheduling.Core.Appointment
{
    public class AppointmentId : EntityId
    {
        private Guid _guid;

        public AppointmentId()
        {
            _guid = Guid.NewGuid();
        }

        public AppointmentId(string id)
        {
            _guid = Guid.Parse(id);
        }

        public override string ToString()
        {
            return _guid.ToString();
        }
    }
}