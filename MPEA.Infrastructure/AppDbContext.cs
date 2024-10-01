using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MPEA.Domain.Models;

namespace MPEA.Infrastructure
{
    class AppDbContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<ExchangePart> ExchangeParts { get; set; }
        public DbSet<ExchangeType> ExchangeTypes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SparePart> SpareParts  { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Warranty> Warrantys { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("MPEA");
                optionsBuilder.UseNpgsql(connectionString);
            }

            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
