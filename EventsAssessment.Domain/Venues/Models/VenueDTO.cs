using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Domain.Venues.Models
{
    public class VenueDTO
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public int Capacity { get; set; }

        public string? Address { get; set; } = null;

        public string? VenueType { get; set; } = null;

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
