using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MPEA.Domain.Models;
using System.Reflection;
using System.Reflection.Emit;

namespace MPEA.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<ExchangeAgreement> ExchangeAgreements { get; set; }
        public DbSet<ExchangeItem> ExchangeItems { get; set; }
        public DbSet<ExchangeTerm> ExchangeTerms { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
        public DbSet<RechargeHistory> RechargeHistories { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SparePart> SpareParts  { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
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
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
