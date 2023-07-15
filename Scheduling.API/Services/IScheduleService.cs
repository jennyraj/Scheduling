
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduling.API.Model;

namespace RestAPI.Services
{
    public interface IScheduleService
    {
        
        Task<ScheduleDto> GetAppointment(string timeslot);
        Task<List<ScheduleDto>> GetAppointment();

    }
}