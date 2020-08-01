using System;

namespace Zip.Accounts.Core.Common
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreatedDateTime { get; set; }
        string CreatedBy { get; set; }

        DateTime ModifiedDateTime { get; set; }
        string ModifiedBy { get; set; }
    }

    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
    }


}
