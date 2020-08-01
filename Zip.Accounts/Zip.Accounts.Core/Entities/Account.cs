using System;
using System.Collections.Generic;
using System.Text;
using Zip.Accounts.Core.Common;

namespace Zip.Accounts.Core.Entities
{
    public class Account : BaseEntity
    {
        public int UserId { get; set; }

        public decimal CreditAmount { get; set; }

        public decimal CreditAvailable { get; set; }

        //If the account needs to be kept on hold
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
    }
}
