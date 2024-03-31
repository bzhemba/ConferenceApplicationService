using Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceApplicationSystem;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application.Models.Application>
{
    public void Configure(EntityTypeBuilder<Application.Models.Application> builder)
    {
        builder.HasKey(application => application.Id);
        builder.HasIndex(application => application.Id).IsUnique();
        builder.Property(application => application.UserId).IsRequired();
        builder.Property(application => application.Activity)
            .HasConversion(
                activity => activity.ToString(),
                activity => (ActivityType)Enum.Parse(typeof(ActivityType), activity));
        builder.Property(application => application.Title).HasMaxLength(100)
            .IsRequired();
        builder.Property(application => application.Description)
            .IsRequired(false).HasMaxLength(300);
        builder.Property(application => application.Outline)
            .IsRequired().HasMaxLength(1000);
    }
}