using System.Net.Mime;
using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Application.Infrastructure.DataAccess;

public class ApplicationConfiguration : IEntityTypeConfiguration<Models.Application>
{
    public void Configure(EntityTypeBuilder<Models.Application> builder)
    {
        builder.HasKey(application => application.Id);
        builder.HasIndex(application => application.Id).IsUnique();
        builder.Property(application => application.)
    }
}