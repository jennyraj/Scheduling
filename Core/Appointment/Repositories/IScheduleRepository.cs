using System.Threading.Tasks;

namespace Scheduling.Core.Appointment.Repositories
{
    public interface IScheduleRepository
    {
        Task<Appointment> GetAppointment(string appointmentId);

        Task<object> SaveAppointmentAsync(Appointment appt);
    }
}