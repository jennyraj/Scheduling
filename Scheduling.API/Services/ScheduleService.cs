using Scheduling.API.Model;
using Scheduling.Core.Appointment.Repositories;

namespace RestAPI.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Task<ScheduleDto> GetAppointment(string timeslot)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScheduleDto>> GetAppointment()
        {
            throw new NotImplementedException();
        }



        /*
        public async Task<PersonDto> GetPerson(string personId)
        {
            var person = await _personRepository.GetPerson(personId);
            
            if (person == null) return new PersonDto(); // throw not found exception

            return new PersonDto()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                PersonId = person.Id.ToString(),
                Address = person.PersonAddress!=null ? new AddressDto()
                {
                    City = person.PersonAddress?.City,
                    Country = person.PersonAddress?.Country,
                    Street = person.PersonAddress?.Street,
                    ZipCode = person.PersonAddress?.ZipCode
                } : null
            };
        }
         */
    }
}