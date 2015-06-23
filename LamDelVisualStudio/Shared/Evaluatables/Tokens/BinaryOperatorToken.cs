using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Evaluatables.Tokens
{
    class BinaryOperatorToken : OperatorToken
    {
        private Func<decimal, decimal, decimal> _rawFunc;

        public Func<decimal, decimal, decimal> RawFunction { get { return _rawFunc; } }


        public BinaryOperatorToken(int priority, Func<decimal, decimal, decimal> func)
            : base(priority, 2)
        {

            _rawFunc = func;
        }
    }
}
