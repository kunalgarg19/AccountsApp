using System;
using System.Collections.Generic;
using System.Text;
using Zip.Accounts.Core.Common;

namespace Zip.Accounts.Core.Dtos
{
    public class UserDto : BaseDto
    {
        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }

        public decimal MonthlySalary { get; set; }

        public decimal MonthlyExpenses { get; set; }
    }
}
