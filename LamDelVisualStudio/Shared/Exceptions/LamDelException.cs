using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Exceptions
{
    public class LamDelException : Exception
    {
        public LamDelException()
        {

        }

        public LamDelException(string message)
            : base(message)
        {

        }

        public LamDelException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
