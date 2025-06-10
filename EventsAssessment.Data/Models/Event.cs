using System;
using System.Collections.Generic;

namespace EventsAssessment.Data.Models;

public partial class Event: IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int EventTypeId { get; set; }

    public int EventStatusId { get; set; }

    public virtual Eventstatus EventStatus { get; set; } = null!;

    public virtual Eventtype EventType { get; set; } = null!;

    public virtual ICollection<Eventshow> Eventshows { get; set; } = new List<Eventshow>();
}
