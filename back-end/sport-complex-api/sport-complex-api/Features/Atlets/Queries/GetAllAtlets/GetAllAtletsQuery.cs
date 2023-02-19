using MediatR;
using sport_complex_api.Features.Atlets.Models;

namespace sport_complex_api.Features.Atlets.Queries.GetAllAtlets
{
    public class GetAllAtletsQuery : IRequest<AtletDto[]>
    {
    }
}
