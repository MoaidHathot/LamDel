using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Types
{
    class BinaryOperator : Operator
    {
        private Func<IEvaluatable, IEvaluatable, decimal> _func;
        private Func<decimal, decimal, decimal> _rawFunc;

        private IEvaluatable _firstArg;
        private IEvaluatable _secondArg;

        public Func<IEvaluatable, IEvaluatable, decimal> Function { get { return _func; } }
        public Func<decimal, decimal, decimal> RawFunction { get { return _rawFunc; } }


        public BinaryOperator(OperatorPriority priority, Func<decimal, decimal, decimal> func)
            : base(priority, 2)
        {

            _func = (a, b) => func(a.Evaluate(), b.Evaluate());
            _rawFunc = func;
        }

        public BinaryOperator(OperatorPriority priority, IEvaluatable first, IEvaluatable second, Func<decimal, decimal, decimal> func)
            : base(priority, 0)
        {
            _firstArg = first;
            _secondArg = second;

            _func = (a, b) => func(first.Evaluate(), second.Evaluate());
            _rawFunc = func;
        }

        protected override decimal InnerEvaluate(params decimal[] args)
        {
            if (null != _secondArg)
            {
                return _func(null, null);
            }

            return _func(new Constant(args[0]), new Constant(args[1]));
        }
    }
}
