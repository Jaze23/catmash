using System;
using System.Collections.Generic;
using System.Net.Http;
using CatMash.Models;
using CatMash.Repositories.Cats;
using CatMash.Services.Cats;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CatMash.Services
{
    public class DbService : IDbService
    {
        private readonly ICatsService _catsService;
        public DbService(ICatsService catsService)
        {
            _catsService = catsService;
        }

        public SqliteConnection GetConnection()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "Db/CatMash.db";
            return new SqliteConnection(connectionStringBuilder.ConnectionString);
        }

        public void CreateTables()
        {

            var sql = @"
                CREATE TABLE IF NOT EXISTS Cats(
                Id Varchar,
                Url Varchar,
                UNIQUE(Id)
                );
                CREATE TABLE IF NOT EXISTS Votes(
                CatId Varchar,
                NbrOfVotes int,
                UNIQUE(CatId)
                );
            ";
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void PopulateDatabase()
        {
            _catsService.PopulateCats();
        }
    }
}
