using System;
using System.Collections.Generic;

namespace EventsAssessment.Data.Models;

public partial class Venue : IEntity
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int Capacity { get; set; }

    public string? Address { get; set; }

    public int VenueTypeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Eventshow> Eventshows { get; set; } = new List<Eventshow>();

    public virtual Venuetype VenueType { get; set; } = null!;
}
