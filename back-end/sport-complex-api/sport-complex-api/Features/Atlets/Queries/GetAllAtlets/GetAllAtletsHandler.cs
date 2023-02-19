using MediatR;
using sport_complex_api.Features.Atlets.Models;

namespace sport_complex_api.Features.Atlets.Queries.GetAllAtlets
{
    public class GetAllAtletsHandler : IRequestHandler<GetAllAtletsQuery, AtletDto[]>
    {
        public Task<AtletDto[]> Handle(GetAllAtletsQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(new[]
            {
                new AtletDto
                {
                    FullName = "Ezepenko R.O",
                    Age = 21
                },
                new AtletDto
                {
                    FullName = "Lather N.A",
                    Age = 21
                },
                new AtletDto
                {
                    FullName = "Kachalka N.C",
                    Age = 21
                },
                new AtletDto
                {
                    FullName = "Pichuk A.U",
                    Age = 21
                },
                new AtletDto
                {
                    FullName = "Rakitski A.A",
                    Age = 26
                },
                new AtletDto
                {
                    FullName = "Pudgachok A.A",
                    Age = 30
                },
                new AtletDto
                {
                    FullName = "Kazachok A.I",
                    Age = 27
                },
                new AtletDto
                {
                    FullName = "Samdev M.N",
                    Age = 30
                },
                new AtletDto
                {
                    FullName = "Garskalyap A.E",
                    Age = 34
                },
                new AtletDto
                {
                    FullName = "Kudin S.S",
                    Age = 36
                },
            });
    }
}
