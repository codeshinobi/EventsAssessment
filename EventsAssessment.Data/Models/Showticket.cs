using System;
using System.Collections.Generic;

namespace EventsAssessment.Data.Models;

public partial class Showticket
{
    public string Id { get; set; } = null!;

    public int EventShowId { get; set; }

    public int TicketStatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Eventshow EventShow { get; set; } = null!;

    public virtual Ticketstatus TicketStatus { get; set; } = null!;
}
