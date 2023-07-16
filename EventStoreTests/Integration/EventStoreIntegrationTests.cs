using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Scheduling.Core.Appointment;
using Scheduling.Core.Appointment.Repositories;
using Scheduling.EventStoreProjectTests.Infrastructure;
using Scheduling.Infrastructure.Factories;
using Scheduling.Infrastructure.Repositories;

namespace Scheduling.EventStoreProjectTests.Integration
{
    [TestFixture]
    public class EventStoreIntegrationTests : IntegrationTestBase
    {
        private IEventStore _eventStore;
        private IScheduleRepository _scheduleRepository;

        [SetUp]
        public void SetUp()
        {
            _eventStore = new EventStoreRepository(new SqlConnectionFactory(ConnectionString));
            _scheduleRepository = new ScheduleRepository(_eventStore);
        }

        [Test]
        public async Task Given_ApptAggregateCreated_When_SavedToEventStore_Then_ShouldBeTheSameWhenFetched()
        {
            var apptId = new AppointmentId();

            var apptAggregate = Appointment.CreateNewAppointment("8:00AM", "patient123", "user1");

            await _eventStore.SaveAsync(apptId, apptAggregate.Version, apptAggregate.DomainEvents, "ApptAggregate");

            var results = await _eventStore.LoadAsync(apptId);

            var fetchedAppt = new Appointment(results);
            Assert.IsNotNull(results);
            Assert.AreEqual(apptAggregate, fetchedAppt);
        }


        [Test]
        public async Task Fetch_NonExistentApptFromRepo_Should_Return_NUll()
        {
            var apptId = new AppointmentId();

            var results = await _scheduleRepository.GetAppointment(apptId.ToString());

            results.Should().BeNull();
        }
    }
}