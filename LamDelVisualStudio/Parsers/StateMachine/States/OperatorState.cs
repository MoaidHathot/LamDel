using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;
using LamDel.Parsers;

namespace LamDel.Parsers.StateMachine.States
{
    class OperatorState : StateBase
    {
        private char _ch;

        public OperatorState(char ch)
        {
            _ch = ch;
        }

        protected override Dictionary<char, Func<char, StatePassage>> CreatePassageMap()
        {
            var baseMap = SharedPassages.GetOperatorPassagesMap((ch) => this);

            foreach (var pair in SharedPassages.GetIntegerPassagesMap((ch) => new IntegerState(ch), (ch) => CurrentToken))
            {
                baseMap[pair.Key] = pair.Value;
            }

            return baseMap;
        }

        protected override IEvaluatable CurrentToken
        {
            get { return Symbols.Default.Operators[_ch]; }
        }

        protected override void ProcessInput(char ch)
        {
            
        }
    }
}
