using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scheduling.API.Model;

namespace Scheduling.API.Services
{
    public interface IScheduleService
    {
        /// <summary>
        /// GetAppointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        Task<AppointmentDto> GetAppointment(string appointmentId);

        /// <summary>
        /// CreateAppointment
        /// </summary>
        /// <param name="GenerateAppointmentDto"></param>
        /// <returns></returns>
        Task<object> CreateAppointment([FromBody] GenerateAppointmentDto appt);

        /// <summary>
        /// CancelAppointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        Task<AppointmentDto> CancelAppointment(string appointmentId, string updatedBy);
    }
}