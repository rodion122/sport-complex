using MediatR;
using Microsoft.AspNetCore.Mvc;
using sport_complex_api.Features.Places.Queries.GetAllPlaces;

namespace sport_complex_api.Features.Places
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlacesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaces()
        {
            var atlets = await _mediator.Send(new GetAllPlacesQuery());

            return Ok(atlets);
        }
    }
}
