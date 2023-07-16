using System.Threading.Tasks;
using Scheduling.API.Model;

namespace Scheduling.API.Services
{
    public interface IScheduleService
    {
        
         Task<AppointmentDto> GetAppointment(string appointmentId);
         Task<AppointmentDto> CancelAppointment(string appointmentId, string updatedBy);
    }
}