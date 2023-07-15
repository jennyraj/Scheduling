using System.Threading.Tasks;
using NUnit.Framework;
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
        public async Task Given_PersonAggregateCreated_When_SavedToEventStore_Then_ShouldBeTheSameWhenFetched()
        {
          /*  var personId = new PersonId();

            var personAggregate = Person.CreateNewPerson("Ben", "Ar");

            await _eventStore.SaveAsync(personId,personAggregate.Version, personAggregate.DomainEvents, "PersonAggregate");
            
            var results = await _eventStore.LoadAsync(personId);

            var fetchedPerson = new Person(results);
            Assert.IsNotNull(results);
            Assert.AreEqual(personAggregate, fetchedPerson);*/
        }

        [Test]
        public async Task Given_PersonAggregate_When_AddressChanged_Then_ShouldBeTheSameWhenFetched()
        {
            /*
            var personId = new PersonId();

            var personAggregate = Person.CreateNewPerson("Chuck", "Norris");
            personAggregate.ChangePersonAddress("street1", "country1", "111222", "city");

            await _eventStore.SaveAsync(personId, personAggregate.Version, personAggregate.DomainEvents, "PersonAggregate");

            var results = await _eventStore.LoadAsync(personId);

            var fetchedPerson = new Person(results);
            Assert.IsNotNull(results);
            Assert.AreEqual(fetchedPerson.PersonAddress.City, "city");
            Assert.AreEqual(fetchedPerson.PersonAddress.Country, "country1");
            Assert.AreEqual(fetchedPerson.PersonAddress.ZipCode, "111222");
            Assert.AreEqual(fetchedPerson.PersonAddress.Street, "street1");
            */
        }

        [Test]
        public async Task Given_PersonAggregate_When_AddressChanged_Then_FetchWithPersonRepository()
        {
          /*  var personId = new PersonId();

            var personAggregate = Person.CreateNewPerson("Chuck", "Norris");
            personAggregate.ChangePersonAddress("street1", "country1", "111222", "city");

            await _eventStore.SaveAsync(personId, personAggregate.Version, personAggregate.DomainEvents, "PersonAggregate");

            var results = await _appointmentRepository.GetPerson(personId.ToString());
            results.LastName.Should().Be("Norris");
            results.FirstName.Should().Be("Chuck");
            */
        }

        [Test]
        public async Task Fetch_NonExistentPersonFromRepo_Should_Return_NUll()
        {
            /*
            var personId = new PersonId();

            var results = await _appointmentRepository.GetPerson(personId.ToString());

            results.Should().BeNull();*/

        }
    }
}