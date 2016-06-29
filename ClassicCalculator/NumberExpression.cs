using ClassicCalculator.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalculator
{
    class NumberExpression : Expression
    {
        private readonly double _value ;

        public NumberExpression(double value)
        {
            this._value = value;
        }
        public override double EvaluateExpression()
        {
            return _value;
        }
    }
}
