using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EventsAssessment.Data.Models;

public partial class EventsAssessmentContext : DbContext
{
    public EventsAssessmentContext()
    {
    }

    public EventsAssessmentContext(DbContextOptions<EventsAssessmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Eventshow> Eventshows { get; set; }

    public virtual DbSet<Eventstatus> Eventstatuses { get; set; }

    public virtual DbSet<Eventtype> Eventtypes { get; set; }

    public virtual DbSet<Showstatus> Showstatuses { get; set; }

    public virtual DbSet<Showticket> Showtickets { get; set; }

    public virtual DbSet<Ticketstatus> Ticketstatuses { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    public virtual DbSet<Venuetype> Venuetypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=EventsAssessment;Username=postgres;Password=Sabatha@00100");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_pkey");

            entity.ToTable("event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EventStatusId)
                .HasDefaultValue(1)
                .HasColumnName("event_status_id");
            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.EventStatus).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_event_status");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_event_type");
        });

        modelBuilder.Entity<Eventshow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("eventshow_pkey");

            entity.ToTable("eventshow");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EventEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("event_end");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("event_start");
            entity.Property(e => e.ShowStatusId)
                .HasDefaultValue(1)
                .HasColumnName("show_status_id");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.HasOne(d => d.Event).WithMany(p => p.Eventshows)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_show_event");

            entity.HasOne(d => d.ShowStatus).WithMany(p => p.Eventshows)
                .HasForeignKey(d => d.ShowStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_show_status");

            entity.HasOne(d => d.Venue).WithMany(p => p.Eventshows)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_show_venue");
        });

        modelBuilder.Entity<Eventstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("eventstatus_pkey");

            entity.ToTable("eventstatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
        });

        modelBuilder.Entity<Eventtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("eventtype_pkey");

            entity.ToTable("eventtype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
        });

        modelBuilder.Entity<Showstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showstatus_pkey");

            entity.ToTable("showstatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
        });

        modelBuilder.Entity<Showticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showticket_pkey");

            entity.ToTable("showticket");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EventShowId).HasColumnName("event_show_id");
            entity.Property(e => e.TicketStatusId).HasColumnName("ticket_status_id");

            entity.HasOne(d => d.EventShow).WithMany(p => p.Showtickets)
                .HasForeignKey(d => d.EventShowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_event_show");

            entity.HasOne(d => d.TicketStatus).WithMany(p => p.Showtickets)
                .HasForeignKey(d => d.TicketStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ticket_status");
        });

        modelBuilder.Entity<Ticketstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ticketstatus_pkey");

            entity.ToTable("ticketstatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venue_pkey");

            entity.ToTable("venue");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.VenueTypeId).HasColumnName("venue_type_id");

            entity.HasOne(d => d.VenueType).WithMany(p => p.Venues)
                .HasForeignKey(d => d.VenueTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_venue_type");
        });

        modelBuilder.Entity<Venuetype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venuetype_pkey");

            entity.ToTable("venuetype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
