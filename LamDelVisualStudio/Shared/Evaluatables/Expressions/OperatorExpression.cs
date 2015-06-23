using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Evaluatables.Expressions
{
    abstract class OperatorExpression : EvaluatableBase
    {
        public OperatorExpression(int argsCount)
            : base(argsCount)
        {
            
        }
    }
}
