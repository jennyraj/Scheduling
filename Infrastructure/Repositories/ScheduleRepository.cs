using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scheduling.Core.Appointment;
using Scheduling.Core.Appointment.Repositories;

namespace Scheduling.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IEventStore _eventStore;
        public ScheduleRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public Task<Appointment> GetAppointment(string apptTime)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> GetAppt()
        {
            throw new NotImplementedException();
        }

        public Task<object> SaveAppointmentAsync(object appt)
        {
            throw new NotImplementedException();
        }

        public async Task<object> SaveAppointmentAsync(Appointment appt)
        {
            await _eventStore.SaveAsync(appt.Id, appt.Version, appt.DomainEvents);
            return appt.Id;
        }

        public Task<AppointmentId> UpdateApptAsync(Appointment appt)
        {
            throw new NotImplementedException();
        }

        /* public async Task<Person> GetPerson(string id)
         {
             var personId = new PersonId(id);
             var personEvents = await _eventStore.LoadAsync(personId);

             return personEvents.Count>0 ? new Person(personEvents) : null;
         }

         public async Task<PersonId> SavePersonAsync(Person person)
         {
             await _eventStore.SaveAsync(person.Id, person.Version, person.DomainEvents);
             return person.Id;
         }
 */

    }
}