using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared.Exceptions;

namespace LamDel.Shared
{
    public abstract class EvaluatableBase : IEvaluatable
    {
        private int _argsCount;

        protected EvaluatableBase(int argsCount)
        {
            if (0 > argsCount)
            {
                throw new ArgumentException("input should be positive", "argsCount");
            }

            _argsCount = argsCount;
        }

        public decimal Evaluate(params decimal[] args)
        {
            if (null == args || 0 == args.Length)
            {
                if (0 != _argsCount)
                {
                    throw new TooFewArgumentsException(_argsCount, args.Length);
                }
            }
            else
            {
                if (args.Length < _argsCount)
                {
                    throw new TooFewArgumentsException(_argsCount, args.Length);
                }
                else if (args.Length > _argsCount)
                {
                    throw new TooManyArgumentsException(_argsCount, args.Length);
                }
            }

            return InnerEvaluate(args);
        }

        protected abstract decimal InnerEvaluate(params decimal[] args);

        public int ArgsCount
        {
            get { return _argsCount; }
            private set { _argsCount = value; }
        }
    }
}
