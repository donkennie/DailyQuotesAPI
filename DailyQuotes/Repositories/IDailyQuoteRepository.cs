using DailyQuotes.DTOs;
using DailyQuotes.Models;

namespace DailyQuotes.Repositories
{
    public interface IDailyQuoteRepository
    {
        Task<Response> GetDailyQuote();
    }
}
