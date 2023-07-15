using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scheduling.Core.Appointment.Repositories
{
    public interface IScheduleRepository
    {
        Task<AppointmentId> UpdateApptAsync(Appointment appt);
        Task<Appointment> GetAppointment(string apptTime);
        Task<List<Appointment>> GetAppt();
    }
}