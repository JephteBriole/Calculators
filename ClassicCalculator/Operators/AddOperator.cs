using ClassicCalculator.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalculator.Operators
{
    class AddOperator : BinaryExpression
    {
        public AddOperator (Expression lValue, Expression rValue)
        {
            base._lValue = lValue;
            base._rValue = rValue;
        }
        public override double EvaluateExpression()
        {
            return base._lValue.EvaluateExpression() + base._rValue.EvaluateExpression();
        }
    }
}
