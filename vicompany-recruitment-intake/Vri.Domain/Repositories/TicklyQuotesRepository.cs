using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Vri.Domain.Interfaces;
using Vri.Domain.Models;

namespace Vri.Domain.Repositories
{
    public class TicklyQuotesRepository : IQuotesRepository
    {
        //by the way, at tickly.vicompany.io under "HTTP Request", there's a typo in .../underlying(s*)/:id :)
        private readonly string url = "https://tickly.vicompany.io/underlyings/";

        public IReadOnlyList<Quote> GetQuotesForIsin(string isin)
        {
            using var client = new HttpClient();
                
            var response = client.GetAsync(this.url + isin).Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                var ticklyQuotes = JsonConvert.DeserializeObject<TicklyQuotesDto>(json);

                return ticklyQuotes.ToQuotes();
            }
            else
            {
                Console.WriteLine($"Failed to fetch data from Tickly: {response.StatusCode}");
                return default;
            }
        }
    }
}
