namespace sport_complex_api.Features.Competitons.Models
{
    public class CompetitonDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        //public string[] AtletIds { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Photo { get; set; }

        public string ApartamentId { get; set; }

        public string Description { get; set; }
    }
}
