using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;
using LamDel.Shared.Types;

namespace LamDel.Parsers
{
    class Symbols
    {
        private static readonly Symbols _default = new Symbols();
        private Dictionary<char, IOperator> _operators = new Dictionary<char, IOperator>();

        public static Symbols Default { get { return _default; } }
        public Dictionary<char, IOperator> Operators { get { return _operators; } }

        private Symbols()
        {
            InitDefaultOperators();
        }

        private void InitDefaultOperators()
        {
            _operators['+'] = new BinaryOperator(OperatorPriority.Low, (a, b) => a + b);
            _operators['-'] = new BinaryOperator(OperatorPriority.Low, (a, b) => a - b);
            _operators['*'] = new BinaryOperator(OperatorPriority.High, (a, b) => a * b);
            _operators['/'] = new BinaryOperator(OperatorPriority.High, (a, b) => a / b);
            _operators['^'] = new BinaryOperator(OperatorPriority.High, (a, b) => (decimal)Math.Pow((double)a, (double)b));
        }
    }
}
