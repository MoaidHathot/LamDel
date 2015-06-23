using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Exceptions
{
    public class TooFewArgumentsException : WrongArgumentNumberException
    {
        public TooFewArgumentsException()
        {

        }

        public TooFewArgumentsException(int expected, int provided)
            : base(expected, provided)
        {

        }

        public TooFewArgumentsException(string message)
            : base(message)
        {

        }

        public TooFewArgumentsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
