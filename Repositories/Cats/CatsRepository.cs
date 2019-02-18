using System;
using System.Collections.Generic;
using CatMash.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CatMash.Repositories.Cats
{
    public class CatsRepository : ICatsRepository
    {
        public SqliteConnection GetConnection()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "Db/CatMash.db";
            return new SqliteConnection(connectionStringBuilder.ConnectionString);
        }

        public IEnumerable<Cat> GetAllCats()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Cat>("SELECT * FROM Cats");
            }
        }

        public void InsertIfDoesNotExistCat(Cat cat)
        {
            var sql = @"
            INSERT OR IGNORE INTO Cats(Id, Url)
            VALUES(@Id, @Url)
            ";
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.AddWithValue("@Id", cat.Id);
                command.Parameters.AddWithValue("@Url", cat.Url);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

    }
}
