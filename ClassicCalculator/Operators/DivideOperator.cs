using ClassicCalculator.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalculator.Operators
{
    class DivideOperator : BinaryExpression
    {
        public DivideOperator(Expression lValue, Expression rValue)
        {
            base._lValue = lValue;
            base._rValue = rValue;
        }
        public override double EvaluateExpression()
        {
            return base._rValue.EvaluateExpression() != 0 ? base._lValue.EvaluateExpression() / base._rValue.EvaluateExpression() : double.NaN;
        }
    }
}
