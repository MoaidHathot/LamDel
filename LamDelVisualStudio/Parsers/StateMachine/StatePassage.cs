using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;

namespace LamDel.Parsers.StateMachine
{
    class StatePassage
    {
        public IState NextState { get; set; }
        public IEvaluatable Token { get; set; }
    }
}
