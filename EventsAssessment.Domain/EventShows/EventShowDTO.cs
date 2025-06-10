using EventsAssessment.Domain.Events.Models;
using EventsAssessment.Domain.Venues.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Domain.EventShows
{
    public class EventShowDTO
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int VenueId { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }

        public int ShowStatusId { get; set; }

        public DateTime CreatedAt { get; set; }

        public EventDTO Event { get; set; } = null!;

        public string ShowStatus { get; set; } = null!;

        public virtual VenueDTO Venue { get; set; } = null!;
    }
}
