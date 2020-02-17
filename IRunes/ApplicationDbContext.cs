namespace IRunes
{
    using Microsoft.EntityFrameworkCore;

    using IRunes.Models;

    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =.\SQLEXPRESS; Database = IRunes; Integrated Security = true");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Album> Albums { get; set; }
    }
}
