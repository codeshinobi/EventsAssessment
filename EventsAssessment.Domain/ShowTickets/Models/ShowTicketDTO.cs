using EventsAssessment.Domain.EventShows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Domain.ShowTickets.Models
{
    public  class ShowTicketDTO
    {
        public string Id { get; set; } = null!;

        public int EventShowId { get; set; }

        public int TicketStatusId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? TicketStatus { get; set; } = null;

        public EventShowDTO EventShow { get; set; }
    }
}
