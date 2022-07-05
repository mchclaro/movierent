using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace MovieRent.API.Data.EntityConfigurations
{
    internal class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Rent");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.RentalDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.ReturnDate)
                .IsRequired()
                .HasColumnType("datetime");
            
            builder.Property<bool>(e => e.IsReturned)
                .HasColumnType("bit");

            builder.HasOne(e => e.Client)
                .WithMany(x => x.Rents)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Movie)
                .WithMany(x => x.Rents)
                .HasForeignKey(e => e.MovieId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}