using DailyQuotes.Core;
using DailyQuotes.DTOs;
using DailyQuotes.Features.Queries;
using DailyQuotes.Models;
using DailyQuotes.Repositories;
using MediatR;

namespace DailyQuotes.Features.Command
{
    public class GetDailyQuoteRequestHandler : IRequestHandler<GetDailyQuoteRequest, ResultResponse<Response>>
    {
        public readonly IDailyQuoteRepository _dailyQuoteRepository;

        public GetDailyQuoteRequestHandler(IDailyQuoteRepository dailyQuoteRepository)
        {
            _dailyQuoteRepository = dailyQuoteRepository;
        }


        public async Task<ResultResponse<Response>> Handle(GetDailyQuoteRequest request, CancellationToken cancellationToken)
        {
            var query = await _dailyQuoteRepository.GetDailyQuote();
            if (query == null)
            {
                return ResultResponse<Response>.Failure("Not Found");
            }

            return ResultResponse<Response>.Success(query);
        }
    }
}
