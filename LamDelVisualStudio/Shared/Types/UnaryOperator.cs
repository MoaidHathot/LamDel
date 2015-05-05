using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Types
{
    class UnaryOperator : Operator
    {
        private Func<decimal, decimal> _func;
        private IEvaluatable arg;

        public UnaryOperator(OperatorPriority priority, Func<decimal, decimal> func)
            : base(priority, 1)
        {
            _func = func;
        }

        protected override decimal InnerEvaluate(params decimal[] args)
        {
            return _func(args[0]);
        }
    }
}
