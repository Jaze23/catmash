using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CatMash.Models;
using CatMash.Repositories.Cats;

namespace CatMash.Services.Cats
{
    public class CatsService : ICatsService
    {
        private readonly ICatsRepository _catsRepository;
        private readonly IHttpClientFactory _clientFactory;
        public CatsService(ICatsRepository catsRepository, IHttpClientFactory clientFactory)
        {
            _catsRepository = catsRepository;
            _clientFactory = clientFactory;
        }

        public IEnumerable<Cat> GetAllOrdered()
        {
            return _catsRepository
            .GetAllCats()
            .OrderByDescending((x) => x.NbrOfVotes)
            .Select((x, i) => new CatResult() { Id = x.Id, Url = x.Url, NbrOfVotes = x.NbrOfVotes, Position = i + 1 });
        }

        public IEnumerable<Cat> GetVersus()
        {
            var list = _catsRepository.GetAllCats().ToList();
            Random random = new Random();
            int rdmNumOne = random.Next(list.Count - 1);
            int rdmNumTwo = 0;
            do
            {
                rdmNumTwo = random.Next(list.Count - 1);
            } while (rdmNumTwo == rdmNumOne);

            var versusList = new List<Cat>() { list[rdmNumOne], list[rdmNumTwo] };

            return versusList;
        }

        public async void PopulateCats()
        {
            var cats = new List<Cat>();

            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://latelier.co/data/cats.json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsAsync<CatsJson>();
                cats = json.Images;
            }

            foreach (var cat in cats)
            {
                _catsRepository.InsertIfDoesNotExistCat(cat);
            }
        }

        public void VoteForCat(string id)
        {
            _catsRepository.VoteForCat(id);
        }
    }
}
