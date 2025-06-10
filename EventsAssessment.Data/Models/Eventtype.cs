using System;
using System.Collections.Generic;

namespace EventsAssessment.Data.Models;

public partial class Eventtype : IEntity
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
