using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Types
{
    class BinaryOperator : Operator
    {
        private Func<decimal, decimal, decimal> _func;

        public BinaryOperator(OperatorPriority priority, Func<decimal, decimal, decimal> func)
            : base(priority, 2)
        {
            _func = func;
        }

        protected override decimal InnerEvaluate(params decimal[] args)
        {
            return _func(args[0], args[1]);
        }
    }
}
