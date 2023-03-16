using DailyQuotes.DTOs;
using DailyQuotes.Models;
using Newtonsoft.Json;
using System.Text;

namespace DailyQuotes.Repositories
{
    public class DailyQuoteRepository: IDailyQuoteRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DailyQuoteRepository> _logger;

        public DailyQuoteRepository(ILogger<DailyQuoteRepository> logger, IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            this._httpClient = clientFactory.CreateClient();
            _configuration = configuration;
            _logger = logger;
        }


        public async Task<Response> GetDailyQuote()
        {
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri("https://favqs.com/api/qotd");
            }

            string apiUri = $"https://favqs.com/api/qotd";
            var response = await _httpClient.GetAsync(apiUri);
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<RootObject>(stringResult);

            return new Response
            {
                Author = json.Quote.Author,
                Body = json.Quote.Body
            };

        }
    }

}
