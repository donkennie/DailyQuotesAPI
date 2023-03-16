using DailyQuotes.Core;
using DailyQuotes.DTOs;
using DailyQuotes.Models;
using MediatR;

namespace DailyQuotes.Features.Queries
{
    public class GetDailyQuoteRequest: IRequest<ResultResponse<Response>>
    {
    }
}
