using System.Threading.Tasks;
using Scheduling.Core.Appointment;
using Scheduling.Core.Appointment.Repositories;

namespace Scheduling.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IEventStore _eventStore;

        public ScheduleRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task<Appointment> GetAppointment(string appointmentId)
        {
            var apptId = new AppointmentId(appointmentId);
            var apptEvents = await _eventStore.LoadAsync(apptId);
            return apptEvents.Count > 0 ? new Appointment(apptEvents) : null;
        }

        public async Task<object> SaveAppointmentAsync(Appointment appt)
        {
            await _eventStore.SaveAsync(appt.Id, appt.Version, appt.DomainEvents);
            return appt.Id;
        }
    }
}