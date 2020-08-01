using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Zip.Accounts.Core.Entities;

namespace Zip.Accounts.Data.EntityTypeConfigurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User> 
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration.ToTable("Users", AccountContext.Schema);

            userConfiguration.HasKey(u => u.Id);

            userConfiguration.HasIndex(u => u.Email).IsUnique();

        }
    }
}
