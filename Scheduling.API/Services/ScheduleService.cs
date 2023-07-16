using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// GetAppointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// CreateAppointment
        /// </summary>
        /// <param name="GenerateAppointmentDto"></param>
        /// <returns></returns>
        public async Task<object> CreateAppointment([FromBody] GenerateAppointmentDto appt)
        {
            var appointment = Appointment.CreateNewAppointment(appt.ApptTime, appt.PatientId, appt.UpdatedBy);
            var apptId = await _scheduleRepository.SaveAppointmentAsync(appointment);

            return apptId;
        }

        /// <summary>
        /// CancelAppointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public async Task<AppointmentDto> CancelAppointment(string appointmentId, string updatedBy)
        {
            var appointment = await _scheduleRepository.GetAppointment(appointmentId);

            if (appointment == null)
                throw new Exception($"Not found {appointmentId}"); // throw appt not found exception

            appointment.CancelAppointment(appointment, updatedBy);
            await _scheduleRepository.SaveAppointmentAsync(appointment);

            return new AppointmentDto
            {
                AppointmentId = appointmentId
                , ApptTime = appointment.ApptTime
                , PatientId = appointment.PatientId
                , UpdatedBy = appointment.UpdatedBy
                , ApptStatus = appointment.ApptStatus
            };
        }
    }
}