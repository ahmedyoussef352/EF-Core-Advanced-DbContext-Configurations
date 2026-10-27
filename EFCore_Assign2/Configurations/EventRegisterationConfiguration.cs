using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Assign2.Configurations;

public class EventRegisterationConfiguration : IEntityTypeConfiguration<EventRegistering>
{
    public void Configure(EntityTypeBuilder<EventRegistering> builder)
    {
        builder.HasKey(er => new { er.EventId, er.AttendeeId });
        // one to many with Attende
        builder.HasOne(er => er.Attendee)
            .WithMany(a => a.Registrations)
            .HasForeignKey(er => er.AttendeeId);
        // one to many with Event
        builder.HasOne(er => er.Event)
            .WithMany(a => a.Registrations)
            .HasForeignKey(er => er.EventId);

    }
}
