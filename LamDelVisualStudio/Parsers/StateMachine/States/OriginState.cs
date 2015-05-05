using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;

namespace LamDel.Parsers.StateMachine.States
{
    class OriginState : StateBase
    {
        protected override Dictionary<char, Func<char, StatePassage>> CreatePassageMap()
        {
            var map = new Dictionary<char, Func<char, StatePassage>>();

            foreach (var pair in SharedPassages.GetIntegerPassagesMap((ch) => new IntegerState(ch)))
            {
                map.Add(pair.Key, pair.Value);
            }

            return map;
        }

        protected override IEvaluatable CurrentToken
        {
            get { return null; }
        }

        protected override void ProcessInput(char ch)
        {
            
        }
    }
}
