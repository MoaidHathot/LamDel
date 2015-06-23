using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Evaluatables.Tokens
{
    class UnaryOperatorToken : OperatorToken
    {
        private Func<decimal, decimal> _func;

        public UnaryOperatorToken(int priority, Func<decimal, decimal> func)
            : base(priority, 1)
        {
            _func = func;
        }
    }
}
