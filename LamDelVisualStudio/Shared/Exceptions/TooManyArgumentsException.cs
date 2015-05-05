using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Exceptions
{
    public class TooManyArgumentsException : WrongArgumentNumberException
    {
        public TooManyArgumentsException()
        {

        }

        public TooManyArgumentsException(int expected, int provided)
            : base(expected, provided)
        {

        }

        public TooManyArgumentsException(string message)
            : base(message)
        {

        }

        public TooManyArgumentsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
