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
            INSERT OR IGNORE INTO Cats(Id, Url, NbrOfVotes)
            VALUES(@Id, @Url, @NbrOfVotes)
            ";
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.AddWithValue("@Id", cat.Id);
                command.Parameters.AddWithValue("@Url", cat.Url);
                command.Parameters.AddWithValue("@NbrOfVotes", cat.NbrOfVotes);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void VoteForCat(string id){
            var sql = @"
            UPDATE Cats
            SET NbrOfVotes = (SELECT NbrOfVotes FROM Cats WHERE Id = @Id) + 1
            WHERE Id = @Id  
            ";
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

    }
}
