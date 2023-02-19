using MediatR;
using sport_complex_api.Features.Places.Models;

namespace sport_complex_api.Features.Places.Queries.GetAllPlaces
{
    public class GetAllPlacesQuery : IRequest<PlaceDto[]>
    {
    }
}
