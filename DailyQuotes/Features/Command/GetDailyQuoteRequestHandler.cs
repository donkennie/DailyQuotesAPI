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
        private readonly IDailyQuoteRepository _dailyQuoteRepository;
        private readonly IEmailSender _emailSender;

        public GetDailyQuoteRequestHandler(IDailyQuoteRepository dailyQuoteRepository, IEmailSender emailSender)
        {
            _dailyQuoteRepository = dailyQuoteRepository;
            _emailSender = emailSender;
        }


        public async Task<ResultResponse<Response>> Handle(GetDailyQuoteRequest request, CancellationToken cancellationToken)
        {
            var query = await _dailyQuoteRepository.GetDailyQuote();
            if (query == null)
            {
                return ResultResponse<Response>.Failure("Not Found");
            }

            var response = new Response()
            {
                Author = query.Author,
                Body = query.Body,
            };


             await _emailSender.SendEmailAsync("ajeigbekehinde160@gmail.com", response.Author , response.Body);

            return ResultResponse<Response>.Success(query);
        }
    }
}
