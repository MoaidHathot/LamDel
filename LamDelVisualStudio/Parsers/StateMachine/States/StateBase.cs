using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;

namespace LamDel.Parsers.StateMachine.States
{
    abstract class StateBase : IState
    {
        private Dictionary<char, Func<char, StatePassage>> _map;
        protected StateMachineContext _context;

        public StateBase(StateMachineContext context)
        {
            _context = context;
            _map = CreatePassageMap();

            foreach (var pair in CreateSharedPassageMap())
            {
                if (!_map.ContainsKey(pair.Key))
                {
                    _map[pair.Key] = pair.Value;
                }
            }
        }

        protected abstract Dictionary<char, Func<char, StatePassage>> CreatePassageMap();

        protected virtual Dictionary<char, Func<char, StatePassage>> CreateSharedPassageMap()
        {
            Func<char, StatePassage> samePassage = (ch) => new StatePassage { NextState = this, Token = null };

            var whiteSpaceMap =  new Dictionary<char, Func<char, StatePassage>>()
            {
                { ' ', samePassage },
                { (char)0, (ch) => new StatePassage { NextState = null, Token = CurrentToken} }
            };

            //Func<char, IState> operatorState = (ch) => new OperatorState();
            //var operatorMap = SharedPassages.GetOperatorPassagesMap(operatorState);

            //foreach (var pair in whiteSpaceMap)
            //{
            //    operatorMap[pair.Key] = pair.Value;
            //}

            //foreach (var pair in SharedPassages.GetIntegerPassagesMap((ch) => new IntegerState(ch)))
            //{
            //    operatorMap[pair.Key] = pair.Value;
            //}

            return whiteSpaceMap;
        }

        public StatePassage Next(char ch)
        {
            if ((char)0 == ch || !_map.ContainsKey(ch))
            {
                return new StatePassage { NextState = null, Token = CurrentToken };
            }

            ProcessInput(ch);

            var func = _map[ch];

            return func(ch);
        }

        protected abstract IEvaluatable CurrentToken { get; }

        protected abstract void ProcessInput(char ch);
    }
}
