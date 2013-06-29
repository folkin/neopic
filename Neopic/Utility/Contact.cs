using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neopic.Utility
{
    public class ContractException : Exception
    {
        public ContractException()
            : base()
        {
        }

        public ContractException(string message)
            : base(message)
        {
        }

        public ContractException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public static class Contract
    {
        [Conditional("CONTRACTS")]
        public static void Requires(Func<bool> requirement)
        {
            if (!requirement())
                throw new ContractException();
        }

        [Conditional("CONTRACTS")]
        public static void Requires(Func<bool> requirement, string message)
        {
            if (!requirement())
                throw new ContractException(message);
        }

        [Conditional("CONTRACTS")]
        public static void Requires(Func<bool> requirement, Func<Exception> throws)
        {
            if (!requirement())
                throw throws();
        }
    }
}
