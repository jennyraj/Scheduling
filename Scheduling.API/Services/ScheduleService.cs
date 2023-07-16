using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Scheduling.API.Model;
using Scheduling.Core.Appointment;
using Scheduling.Core.Appointment.Repositories;

namespace Scheduling.API.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<AppointmentDto> GetAppointment(string appointmentId)
        {
            var appointment = await _scheduleRepository.GetAppointment(appointmentId);
 
            if (appointment == null) return new AppointmentDto(); // throw not found exception

            return new AppointmentDto
            {
                AppointmentId = appointment.Id.ToString()
                , ApptTime = appointment.ApptTime
                , PatientId = appointment.PatientId
                , UpdatedBy = appointment.UpdatedBy
                , ApptStatus = appointment.ApptStatus
            };

        }

        public async Task<object> CreateAppointment(string time)
        {
            var appointment = Appointment.CreateNewAppointment(time);
            var appointmentId = await _scheduleRepository.SaveAppointmentAsync(appointment);
            return appointmentId;
        }

        public async Task<AppointmentDto>  CancelAppointment(string appointmentId, string updatedBy)
        {
            var appointment = await _scheduleRepository.GetAppointment(appointmentId);

            if (appointment == null) throw new Exception($"Not found {appointmentId}"); // throw appt not found exception

            appointment.CancelAppointment(appointment);
            await _scheduleRepository.SaveAppointmentAsync(appointment);

            return new AppointmentDto
            {
                AppointmentId =  appointmentId
                , ApptTime = appointment.ApptTime
                , PatientId = null
                , UpdatedBy = appointment.UpdatedBy
                , ApptStatus = appointment.ApptStatus
            };
        }
    }
}