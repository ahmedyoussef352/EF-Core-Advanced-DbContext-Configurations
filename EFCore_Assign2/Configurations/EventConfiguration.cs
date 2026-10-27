using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Assign2.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasOne(e => e.Organizer)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.OrganizerId);

        builder.HasOne(e => e.ParentEvent)
            .WithMany(e => e.Sessions)
            .HasForeignKey(e => e.ParentEventId)
            .OnDelete(DeleteBehavior.Restrict); // لمنع الحذف التتابعي الدائري

        builder
        .Property<DateTime>("CreatedAt");

        builder
            .Property<DateTime?>("LastModifiedAt");
    }
}
