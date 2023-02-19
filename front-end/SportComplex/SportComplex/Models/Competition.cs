using System;
using System.Collections.Generic;

namespace SportComplex.Models
{
    public class Competition
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> AtletId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Photo { get; set; }

        public string ApartamentId { get; set; }

        public string Description { get; set; }
    }
}
