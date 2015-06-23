using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Parsers.StateMachine.States
{
    class StateMachineContext
    {
        private int _openedParentheses;

        public int OpenedParantheses { get { return _openedParentheses; } }

        public StateMachineContext()
        {

        }

        public int OpenParentheses()
        {
            return ++_openedParentheses;
        }

        public int CloseParentheses()
        {
            return --_openedParentheses;
        }
    }
}
