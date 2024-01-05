using BaiTap.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BaiTap.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<AccountCategory> AccountCategories { get; set; }
        public DbSet<SignIn> SignIn { get; set; }
        public DbSet<SignUp> SignUp { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<JwtOptions> JwtOptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountCategory>()
                .HasKey(ac => new { ac.AccountId, ac.CategoryId });
            modelBuilder.Entity<AccountCategory>()
                .HasOne(a => a.Account)
                .WithMany(ac => ac.AccountCategories)
                .HasForeignKey(a => a.AccountId);
           modelBuilder.Entity<AccountCategory>()
                .HasOne(a => a.Category)
                .WithMany(ac => ac.AccountCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<UserAccount>()
                .HasKey(ua => new { ua.AccountId, ua.UserId });
            modelBuilder.Entity<UserAccount>()
                .HasOne(a => a.Account)
                .WithMany(ac => ac.UsersAccounts)
                .HasForeignKey(a => a.AccountId);
            modelBuilder.Entity<UserAccount>()
                .HasOne(a => a.User)
                .WithMany(ac => ac.UsersAccounts)
                .HasForeignKey(c => c.UserId);
        }


    }
}
