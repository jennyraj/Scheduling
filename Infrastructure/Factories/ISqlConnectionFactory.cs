using System.Data.SqlClient;

namespace Scheduling.Infrastructure.Factories
{
    public interface ISqlConnectionFactory
    {
        SqlConnection SqlConnection();
    }
}