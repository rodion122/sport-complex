namespace sport_complex_api.Features.Places.Models
{
    public class PlaceDto
    {
        public string PlaceDtoId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PositionX  { get; set; }

        public int PositionY { get; set; }

        public int NumberOfSears { get; set; }
    }
}
