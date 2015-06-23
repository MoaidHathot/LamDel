using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;
using LamDel.Shared.Evaluatables.Tokens;

namespace LamDel.Parsers.StateMachine.States
{
    class DoubleState : StateBase
    {
        private decimal _currentState;
        private long _currentPower = 1;

        public DoubleState(StateMachineContext context, decimal state = 0m)
            : base(context)
        {
            _currentState = state;
        }

        protected override Dictionary<char, Func<char, StatePassage>> CreatePassageMap()
        {
            var basePassages = SharedPassages.GetIntegerPassagesMap((ch) => this);

            Func<char, IState> operatorState = (ch) => new OperatorState(_context, ch);
            var operatorMap = SharedPassages.GetOperatorPassagesMap(operatorState, (ch) => new ConstantToken(_currentState));

            foreach (var pair in operatorMap)
            {
                basePassages[pair.Key] = pair.Value;
            }

            return basePassages;
        }

        protected override IEvaluatable CurrentToken { get { return new ConstantToken((decimal)_currentState); } }

        protected override void ProcessInput(char ch)
        {
            _currentPower *= 10;
            _currentState += (decimal)(ch - '0') / _currentPower;
        }
    }
}
