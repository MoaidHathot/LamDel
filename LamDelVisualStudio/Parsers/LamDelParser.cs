using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;
using LamDel.Parsers.StateMachine;

namespace LamDel.Parsers
{
    public class LamDelParser : IParser
    {
        public IEvaluatable Parse(string expression)
        {
            var machine = new LamDelStateMachine(expression);

            return machine.States.FirstOrDefault();
        }
    }
}
