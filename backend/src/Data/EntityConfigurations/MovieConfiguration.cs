using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace MovieRent.API.Data.EntityConfigurations
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(e => e.Classification)
                .IsRequired(true)
                .HasMaxLength(5);
            
            builder.Property(e => e.MovieType)
                .IsRequired(true)
                .HasMaxLength(5);
        }
    }
}