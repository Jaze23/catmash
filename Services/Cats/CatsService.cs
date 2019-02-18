using System.Collections.Generic;
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

        public IEnumerable<Cat> GetAll()
        {
            return _catsRepository.GetAllCats();
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

            foreach(var cat in cats){
                _catsRepository.InsertIfDoesNotExistCat(cat);
            }
        }
    }
}
