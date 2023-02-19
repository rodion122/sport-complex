using MediatR;
using Microsoft.AspNetCore.Mvc;
using sport_complex_api.Features.Competitons.Commands.CreateCopmetition;
using sport_complex_api.Features.Competitons.Commands.UpdateCompetition;
using sport_complex_api.Features.Competitons.Models;
using sport_complex_api.Features.Competitons.Queries.GetCompetitions;


namespace sport_complex_api.Features.Competitons
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class CompetitionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompetitionsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetCompetitions()
        {
            var atlets = await _mediator.Send(new GetCompetitionsQuery());

            return Ok(atlets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompetition([FromBody] CompetitonDto competiton)
        {
            var id = await _mediator.Send(new CreateCopmetitionCommand
            {
                Competiton = competiton
            });

            return Created(nameof(GetCompetitions), id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompetition([FromBody] CompetitonDto competiton)
        {
            await _mediator.Send(new UpdateCopmetitionCommand
            {
                Competiton = competiton
            });

            return Ok();
        }
    }
}
