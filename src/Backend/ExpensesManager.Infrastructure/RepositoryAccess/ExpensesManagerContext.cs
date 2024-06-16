﻿using ExpensesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infrastructure.RepositoryAccess
{
    public class ExpensesManagerContext : DbContext
    {
        public ExpensesManagerContext(DbContextOptions<ExpensesManagerContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpensesManagerContext).Assembly);
        }
    }
}
