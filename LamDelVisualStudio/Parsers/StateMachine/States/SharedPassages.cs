using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;

namespace LamDel.Parsers.StateMachine.States
{
    static class SharedPassages
    {
        internal static Dictionary<char, Func<char, StatePassage>> GetIntegerPassagesMap(Func<char, IState> stateCreator)
        {
            return GetIntegerPassagesMap(stateCreator, (ch) => null);
        }

        internal static Dictionary<char, Func<char, StatePassage>> GetIntegerPassagesMap(Func<char, IState> stateCreator, Func<char, IEvaluatable> tokenCreator)
        {
            Func<char, StatePassage> numberPassage = (ch) => new StatePassage { NextState = stateCreator(ch), Token = tokenCreator(ch) };

            return new Dictionary<char, Func<char, StatePassage>>()
            {
                { '0', numberPassage },
                { '1', numberPassage },
                { '2', numberPassage },
                { '3', numberPassage },
                { '4', numberPassage },
                { '5', numberPassage },
                { '6', numberPassage },
                { '7', numberPassage },
                { '8', numberPassage },
                { '9', numberPassage },
            };
        }

        internal static Dictionary<char, Func<char, StatePassage>> GetOperatorPassagesMap(Func<char, IState> stateCreator)
        {
            return GetOperatorPassagesMap(stateCreator, (ch) => null);
        }

        internal static Dictionary<char, Func<char, StatePassage>> GetOperatorPassagesMap(Func<char, IState> stateCreator, Func<char, IEvaluatable> tokenCreator)
        {
            Func<char, StatePassage> numberPassage = (ch) => new StatePassage { NextState = stateCreator(ch), Token = tokenCreator(ch) };

            return new Dictionary<char, Func<char, StatePassage>>()
            {
                { '+', numberPassage },
                { '-', numberPassage },
                { '*', numberPassage },
                { '/', numberPassage },
                { '^', numberPassage },
            };
        }
    }
}
