using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Evaluatables.Expressions
{
    class BinaryOperatorExpression : OperatorExpression
    {
        private Func<decimal> _evaluationFunc;
        private Func<decimal, decimal, decimal> _calculationFunc;

        private IEvaluatable _firstArg;
        private IEvaluatable _secondArg;

        public BinaryOperatorExpression(IEvaluatable firstArg, IEvaluatable secondArg, Func<decimal, decimal, decimal> func)
            : base(0)
        {
            _firstArg = firstArg;
            _secondArg = secondArg;

            _calculationFunc = func;
            _evaluationFunc = () => _calculationFunc(_firstArg.Evaluate(), _secondArg.Evaluate());
        }

        protected override decimal InnerEvaluate(params decimal[] args)
        {
            return _evaluationFunc();
        }
    }
}
