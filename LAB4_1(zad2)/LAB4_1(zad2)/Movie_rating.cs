using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LAB4_1
{
    public class Movie_rating: DbContext
    {
        public DbSet<Movie> movies { get; set; }
        public DbSet<Review> ratings { get; set; }
        public Movie_rating()
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = ContactsDb.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasKey(r => r.Id);
            modelBuilder.Entity<Movie>().HasMany<Review>().WithOne().HasForeignKey(e => e.Movie_id).IsRequired();

        }

    }

}
