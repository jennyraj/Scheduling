using System;
using System.Data.SqlClient;
using NUnit.Framework;
using Schedluing.DbMigration;

namespace Scheduling.EventStoreProjectTests.Infrastructure
{
    [SetUpFixture]
    public abstract class IntegrationTestBase
    {
        public string ConnectionString { get; set; }
        private string _databaseName { get; set; }

        [OneTimeSetUp]
        public void StartDatabase()
        {
            _databaseName = Guid.NewGuid().ToString();
            ConnectionString = $@"Server=(localdb)\mssqllocaldb;Database={_databaseName};Trusted_Connection=True;";
            Program.Main(new string[] {ConnectionString});
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conn;

                    command.CommandText = "USE master";
                    command.ExecuteNonQuery();

                    command.CommandText = $"DROP DATABASE \"{_databaseName}\"";
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}