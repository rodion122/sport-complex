using MediatR;
using sport_complex_api.Features.Competitons.Models;

namespace sport_complex_api.Features.Competitons.Commands.UpdateCompetition
{
    public class UpdateCopmetitionCommand : IRequest
    {
        public CompetitonDto Competiton { get; set; }
    }
}
