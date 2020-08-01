using Zip.Accounts.Core.Common;

namespace Zip.Accounts.Core.Dtos
{
    public class AccountDto : BaseDto
    {
        public int UserId { get; set; }

        public decimal CreditAmount { get; set; }

        public decimal CreditAvailable { get; set; }

        //If the account needs to be kept on hold
        public bool IsActive { get; set; }
    }
}
