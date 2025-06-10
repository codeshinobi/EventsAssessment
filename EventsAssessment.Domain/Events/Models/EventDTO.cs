using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAssessment.Domain.Events.Models
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null; 
        public string? Type { get; set; } = null;
        public string? Description { get; set; } = null;

    }
}
