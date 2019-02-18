using System.Collections.Generic;
using CatMash.Models;

namespace CatMash.Repositories.Cats
{
    public interface ICatsRepository
    {
        IEnumerable<Cat> GetAllCats();
        void InsertIfDoesNotExistCat(Cat cat);
    }
}
