using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MovieRent.API.Data.EntityConfigurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(e => e.CPF)
                .IsRequired(false)
                .HasMaxLength(11);
        }
    }
}