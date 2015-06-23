using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Evaluatables.Tokens
{
    public abstract class OperatorToken : IOperator, IPrioritized
    {
        private int _priority;
        public int Priority { get { return _priority; } set { _priority = value; } }

        private int _argsCount;
        public int ArgsCount { get { return _argsCount; } }

        public OperatorToken(int priority, int argsCount)
        {
            _priority = priority;
            _argsCount = argsCount;
        }

        public decimal Evaluate(params decimal[] args)
        {
            throw new NotImplementedException();
        }
    }
}
