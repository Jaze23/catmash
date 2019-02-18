using System.Collections.Generic;
using System.Net.Http;
using CatMash.Models;

namespace CatMash.Services
{
    public interface IDbService
    {
        void CreateTables();
        void PopulateDatabase();
    }
}
