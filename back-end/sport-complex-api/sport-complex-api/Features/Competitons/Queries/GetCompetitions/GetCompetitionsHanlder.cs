using MediatR;
using Microsoft.EntityFrameworkCore;
using sport_complex_api.Features.Competitons.Models;
using sport_complex_api.Infastructure.Database.Contexts;

namespace sport_complex_api.Features.Competitons.Queries.GetCompetitions
{
    public class GetCompetitionsHanlder : IRequestHandler<GetCompetitionsQuery, CompetitonDto[]>
    {
        private CommonContext _context;

        public GetCompetitionsHanlder(CommonContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<CompetitonDto[]> Handle(GetCompetitionsQuery request, CancellationToken cancellationToken)
        {
            var data =  _context.Set<CompetitonDto>().AsNoTracking();

            return request.CompetitionIds?.Any() == true
                ? data.Where(el => request.CompetitionIds.Contains(el.Id)).ToArrayAsync(cancellationToken)
                : data.ToArrayAsync(cancellationToken);
        }
    }
}
