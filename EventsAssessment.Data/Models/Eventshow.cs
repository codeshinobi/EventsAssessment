using System;
using System.Collections.Generic;

namespace EventsAssessment.Data.Models;

public partial class Eventshow : IEntity
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public int VenueId { get; set; }

    public DateTime EventStart { get; set; }

    public DateTime EventEnd { get; set; }

    public int ShowStatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Showstatus ShowStatus { get; set; } = null!;

    public virtual ICollection<Showticket> Showtickets { get; set; } = new List<Showticket>();

    public virtual Venue Venue { get; set; } = null!;
}
