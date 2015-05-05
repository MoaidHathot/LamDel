using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;
using LamDel.Shared.Exceptions;
using LamDel.Parsers.StateMachine.States;

namespace LamDel.Parsers.StateMachine
{
    class LamDelStateMachine : IStateMachine
    {
        private IState _currentState;
        private string _input;

        public LamDelStateMachine(string input)
        {
            _input = input;

            _currentState = new OriginState();
        }

        public IEnumerable<IEvaluatable> States
        {
            get
            {
                foreach(var ch in _input)
                {
                    var passage = _currentState.Next(ch);
                    _currentState = passage.NextState;

                    if (null != passage.Token)
                    {
                        yield return passage.Token;
                    }
                }

                yield return _currentState.Next((char)0).Token;
            }
        }
    }
}
