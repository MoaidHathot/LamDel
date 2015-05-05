using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared.Types
{
    class Constant : EvaluatableBase
    {
        private decimal _constant;

        public Constant(decimal constant)
            : base(0)
        {
            _constant = constant;
        }

        
        protected override decimal InnerEvaluate(params decimal[] args)
        {
            return _constant;
        }
    }
}
