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
        [Route("/Appointments")]
        [SwaggerResponse((int) System.Net.HttpStatusCode.OK, Type = typeof(AppointmentDto))]
        public async Task<object> CreateAppointment([FromBody] GenerateAppointmentDto appt)
        {
            var apptId = await _scheduleService.CreateAppointment(appt);
            return new {AppointmentId = apptId.ToString()};
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
        [Route("/Appointments/{appointmentId}")]
        [SwaggerResponse((int) System.Net.HttpStatusCode.OK, Type = typeof(AppointmentDto))]
        public async Task<AppointmentDto> GetAppointment([FromRoute] string appointmentId)
        {
            return await _scheduleService.GetAppointment(appointmentId);
        }

        /// <summary>
        ///CancelAppointment:
        ///The rest of the work flows
        /// like Insurance validation, Referring Doctor Notification etc can start now. 
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("/Appointments/{appointmentId}")]
        [SwaggerResponse((int) System.Net.HttpStatusCode.OK, Type = typeof(AppointmentDto))]
        public async Task<AppointmentDto> CancelAppointment([FromRoute] string appointmentId
            , [FromQuery] string updatedBy)
        {
            return await _scheduleService.CancelAppointment(appointmentId, updatedBy);
        }
    }
}