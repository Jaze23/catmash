using System.Collections.Generic;
using CatMash.Models;

namespace CatMash.Services.Cats
{
    public interface ICatsService
    {
        void PopulateCats();
        IEnumerable<Cat> GetAll();
    }
}
