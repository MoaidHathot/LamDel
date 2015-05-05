using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LamDel.Shared
{
    public interface IParser
    {
        IEvaluatable Parse(string expression);
    }
}
