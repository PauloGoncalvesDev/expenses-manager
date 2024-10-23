using ExpensesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infrastructure.RepositoryAccess
{
    public class ExpensesManagerContext : DbContext
    {
        public ExpensesManagerContext(DbContextOptions<ExpensesManagerContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<AdditionalInfoUser> AdditionalInfoUser { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<UserImage> UserImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpensesManagerContext).Assembly);
        }
    }
}
