using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Exceptions
{
    public class WrongArgumentNumberException : LamDelException
    {
        public WrongArgumentNumberException()
        {

        }

        public WrongArgumentNumberException(int expected, int provided)
            : this(string.Format("{0} arguments expected but {1} arguments were provided", expected, provided))
        {

        }

        public WrongArgumentNumberException(string message)
            : base(message)
        {

        }

        public WrongArgumentNumberException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
