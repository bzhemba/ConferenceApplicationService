using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Infrastructure.DataAccess;

public class ApplicationConfiguration : IEntityTypeConfiguration<Models.Application>
{
    public void Configure(EntityTypeBuilder<Models.Application> builder)
    {
        builder.HasKey(application => application.Id);
        builder.HasIndex(application => application.Id).IsUnique();
        builder.Property(application => application.Title).HasMaxLength(100).IsRequired();
        builder.Property(application => application.Description).IsRequired(false).HasMaxLength(300);
        builder.Property(application => application.Plan).IsRequired().HasMaxLength(1000);
    }
}