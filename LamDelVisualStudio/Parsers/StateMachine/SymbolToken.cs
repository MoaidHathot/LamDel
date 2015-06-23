using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;

namespace LamDel.Parsers.StateMachine
{
    class SymbolToken
    {
        private int _basePriority;
        public int BasePriority { get { return _basePriority; } }

        private Func<int, IOperator> _operatorCreator;

        public SymbolToken(int basePriority, Func<int, IOperator> operatorCreator)
        {
            _basePriority = basePriority;
            _operatorCreator = operatorCreator;
        }

        public IOperator CreateOperator(int priority)
        {
            return _operatorCreator(priority);
        }
    }
}
