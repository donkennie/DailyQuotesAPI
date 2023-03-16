using DailyQuotes.Features.Queries;
using DailyQuotes.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyQuotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyQuoteController : ControllerBase
    {
        public IMediator _mediator;
        public DailyQuoteController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet("location")]
        [ProducesResponseType(typeof(RootObject), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(BaseCommandResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCurrentWeatherByLocation()
        {
           var result = await _mediator.Send(new GetDailyQuoteRequest() { });
           return Ok(result);
        }
    }
}
