

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("Creating models...");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}