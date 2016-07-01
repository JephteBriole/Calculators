using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalculator
{
    class CalculatorUI
    {
        private ExpressionBuilder _exprBuilder;

        #region Constructor
        public CalculatorUI()
        {
            this._exprBuilder = new ExpressionBuilder();
        }
        #endregion

        #region Computation Launcher
        public void Run()
        {
            while (!_exprBuilder.ExitFlag)
            {
                Console.Write("Calculator > ");
                string userInput = Console.ReadLine().Trim();
                _exprBuilder.ParseExpression(userInput);
               // _exprBuilder.Display();
            }
        }
        #endregion
    }
}
