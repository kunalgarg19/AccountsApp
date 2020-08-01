using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Zip.Accounts.Core.Entities;

namespace Zip.Accounts.Data.EntityTypeConfigurations
{
    class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> accountConfiguration)
        {
            accountConfiguration.ToTable("Accounts", AccountContext.Schema);

            accountConfiguration.HasKey(a => a.Id);

            accountConfiguration.HasOne(a => a.User).WithMany().HasForeignKey(a => a.UserId);

        }
    }
}
