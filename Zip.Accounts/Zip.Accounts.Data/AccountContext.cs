using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zip.Accounts.Core.Entities;
using Zip.Accounts.Data.EntityTypeConfigurations;

namespace Zip.Accounts.Data
{
    public class AccountContext : DbContext
    {
        public const string Schema = "Zip";             

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}
