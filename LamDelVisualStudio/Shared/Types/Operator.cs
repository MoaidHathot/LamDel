using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Types
{
    public abstract class Operator : EvaluatableBase, IOperator
    {
        private OperatorPriority _priority;
        public OperatorPriority Priority { get { return _priority; } }


        public Operator(OperatorPriority priority, int argsCount)
            : base(argsCount)
        {
            _priority = priority;
        }
    }
}
