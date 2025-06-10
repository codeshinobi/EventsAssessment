using System;
using System.Collections.Generic;

namespace EventsAssessment.Data.Models;

public partial class Venuetype : IEntity
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();
}
