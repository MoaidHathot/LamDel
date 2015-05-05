using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;

namespace LamDel.Parsers.StateMachine
{
    interface IState
    {
        StatePassage Next(char ch);
        //bool IsAccepts(char ch);
        //bool Accept(char ch);

        //IEvaluatable Context { get; }

        //void Reset();
    }
}
