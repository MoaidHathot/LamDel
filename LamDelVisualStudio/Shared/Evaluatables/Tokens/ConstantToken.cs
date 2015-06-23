using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Evaluatables.Tokens
{
    class ConstantToken : IEvaluatable
    {
        private decimal _constant;

        public ConstantToken(decimal constant)
        {
            _constant = constant;
        }

        public decimal Evaluate(params decimal[] args)
        {
            return _constant;
        }
    }
}
