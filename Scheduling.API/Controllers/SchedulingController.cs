using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scheduling.API.Model;
using Scheduling.API.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Scheduling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchedulingController : ControllerBase
    {

        private readonly ScheduleService _scheduleService;

        public SchedulingController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        /// <summary>
        /// Creates new appointment Aggregate using time as parameter
        /// Appointment will be saved as stream of events in event store
        /// </summary>
        /// <returns>Newly created appointment object aggregateId</returns>
        [HttpPost]
        [SwaggerResponse((int) System.Net.HttpStatusCode.OK, Type = typeof(object))]
        public async Task<List<string>> GenerateSchedule()
        {
            var list = new List<string>();
            var dt = new DateTime(2023, 7, 15, 8, 0, 0);
            for (var i=0; i < 18; i++)
            {
                var time = dt.ToShortTimeString();
                var scheduleId = await _scheduleService.CreateAppointment(time);
                list.Add( (scheduleId).ToString() ?? string.Empty);
                dt=dt.AddMinutes(30);
            }

            return list;
        }

        /// <summary>
        /// Fetch aggregate from event store using aggregateId(appointmentId)
        /// This will fetch all the events for given aggregate and mutate
        /// aggregate using each event in sequence, therefore reconstructing
        /// latest aggregate state
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK, Type = typeof(AppointmentDto))]
        public async Task<AppointmentDto> GetAppointment([FromQuery] string appointmentId)
        { 
            return await _scheduleService.GetAppointment(appointmentId);
        }

        /// <summary>
        ///CancelAppointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerResponse((int) System.Net.HttpStatusCode.OK, Type = typeof(AppointmentDto))]
        public async Task<AppointmentDto> CancelAppointment([FromQuery] string appointmentId, string updatedBy)
        {
            return  await _scheduleService.CancelAppointment(appointmentId, updatedBy);

        }
    }


}