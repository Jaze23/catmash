using Dapper;
using Microsoft.Data.Sqlite;

namespace CatMash.Repositories.Cats
{
    public class CatsRepository
    {
        public SqliteConnection GetConnection()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "CatMash.db";
            return new SqliteConnection(connectionStringBuilder.ConnectionString);
        }

    }
}
