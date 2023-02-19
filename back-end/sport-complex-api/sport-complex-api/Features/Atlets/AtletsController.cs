using MediatR;
using Microsoft.AspNetCore.Mvc;
using sport_complex_api.Features.Atlets.Queries.GetAllAtlets;

namespace sport_complex_api.Features.Atlets
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class AtletsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtletsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAtlets()
        {
            var atlets = await _mediator.Send(new GetAllAtletsQuery());

            return Ok(atlets);
        }
    }
}
