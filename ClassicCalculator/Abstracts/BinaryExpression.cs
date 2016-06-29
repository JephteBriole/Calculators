using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalculator.Abstracts
{
    abstract class BinaryExpression : Expression
    {
        protected Expression _lValue;
        protected Expression _rValue;
    }
}
