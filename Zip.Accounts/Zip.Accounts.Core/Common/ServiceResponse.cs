using System;
using System.Collections.Generic;
using System.Text;

namespace Zip.Accounts.Core.Common
{
    public class ServiceResponse<T>
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }
    }
}
