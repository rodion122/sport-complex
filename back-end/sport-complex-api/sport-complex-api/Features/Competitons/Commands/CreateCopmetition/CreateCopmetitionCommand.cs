using MediatR;
using sport_complex_api.Features.Competitons.Models;

namespace sport_complex_api.Features.Competitons.Commands.CreateCopmetition
{
    public class CreateCopmetitionCommand : IRequest<string>
    {
        public CompetitonDto Competiton { get; set; }
    }
}
