﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;
using LamDel.Shared.Evaluatables.Tokens;

namespace LamDel.Parsers.StateMachine.States
{
    class IntegerState : StateBase
    {
        private long _currentState = 0;
        private int _updatesCount;

        public IntegerState(StateMachineContext context, char ch = (char)0)
            : base(context)
        {
            if ((char)0 != ch)
            {
                _currentState = ch - '0';
            }
        }

        protected override Dictionary<char, Func<char, StatePassage>> CreatePassageMap()
        {
            //var baseMap = IntegerState.GetNumberPassagesMap((ch) => this);
            var baseMap = SharedPassages.GetIntegerPassagesMap((ch) => this);

            baseMap.Add('.', (ch) => new StatePassage { NextState = new DoubleState(_context, (decimal)_currentState), Token = null });

            Func<char, IState> operatorState = (ch) => new OperatorState(_context, ch);
            var operatorMap = SharedPassages.GetOperatorPassagesMap(operatorState, (ch) => new ConstantToken(_currentState));

            foreach (var pair in operatorMap)
            {
                baseMap[pair.Key] = pair.Value;
            }

            return baseMap;
        }

        protected override void ProcessInput(char ch)
        {
            if ('0' <= ch && ch <= '9')
            {
                _currentState = (10 * _currentState) + (ch - '0');
                ++_updatesCount;
            }
        }

        protected override IEvaluatable CurrentToken { get { return new ConstantToken(_currentState); } }
    }
}
