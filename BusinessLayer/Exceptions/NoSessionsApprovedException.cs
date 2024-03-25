using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Exceptions
{
    public class NoSessionsApprovedException : Exception
    {
        public NoSessionsApprovedException(string message)
            : base(message)
        {
        }
    }
}
