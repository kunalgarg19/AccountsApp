using System;
using System.Collections.Generic;
using System.Text;
using Zip.Accounts.Core.Common;

namespace Zip.Accounts.Core.Entities
{
    public class User : BaseEntity
    {
        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }

        public decimal MonthlySalary { get; set; }

        public decimal MonthlyExpenses { get; set; }
    }
}
