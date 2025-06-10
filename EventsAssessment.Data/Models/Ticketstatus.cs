using System;
using System.Collections.Generic;

namespace EventsAssessment.Data.Models;

public partial class Ticketstatus : IEntity
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Showticket> Showtickets { get; set; } = new List<Showticket>();
}
