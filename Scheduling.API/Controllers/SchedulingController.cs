using Microsoft.AspNetCore.Mvc;
using Scheduling.API.Services;

namespace Scheduling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {

        private readonly ScheduleService _scheduleService;


        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

 
        /*
        /// <summary>
        /// Fetch aggregate from event store using aggregateId(personId)
        /// This will fetch all the events for given aggregate and mutate
        /// aggregate using each event in sequence, therefore reconstructing
        /// latest aggregate state
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(PersonDto))]
        public async Task<PersonDto> GetPerson([FromQuery] string personId)
        {
            return await _scheduleService.GetPerson(personId);
        }*/

        
    }
}