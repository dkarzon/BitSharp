using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BITSharp.Exceptions
{
    public class BitException : Exception
    {
        public BitException(string message) : base(message)
        {
        }
    }
}
