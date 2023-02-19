using MediatR;
using sport_complex_api.Features.Competitons.Models;

namespace sport_complex_api.Features.Competitons.Queries.GetCompetitions
{
    public class GetCompetitionsQuery : IRequest<CompetitonDto[]>
    {
        public IEnumerable<string> CompetitionIds { get; set; }
    }
}
