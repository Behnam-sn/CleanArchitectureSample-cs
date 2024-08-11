using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class WebinarConfiguration : IEntityTypeConfiguration<Webinar>
{
    public void Configure(EntityTypeBuilder<Webinar> builder)
    {
        builder.ToTable("Webinars");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Name).HasMaxLength(100).IsRequired();
        builder.Property(i => i.ScheduledOn).IsRequired();
    }
}
