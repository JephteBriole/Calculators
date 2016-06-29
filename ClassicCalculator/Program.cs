using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ClassicCalculator.Operators;

namespace ClassicCalculator
{
    class Program
    {

        private CalculatorUI CalculatorUI { get; set; }

        #region Constructor
        public Program()
        {
            this.CalculatorUI = new CalculatorUI();
        }
        #endregion

        static void Main(string[] args)
        {
            #region My Test
            /*AddOperator add = new AddOperator(new NumberExpression(25), new NumberExpression(35));
                var result = add.EvaluateExpression();
                Console.WriteLine(result);

                SubstractOperator substract = new SubstractOperator(new NumberExpression(25), new NumberExpression(35));
                result = substract.EvaluateExpression();
                Console.WriteLine(result);

                MultiplyOperator multiply = new MultiplyOperator(new NumberExpression(5), new NumberExpression(4));
                result = multiply.EvaluateExpression();
                Console.WriteLine(result);

                DivideOperator divide = new DivideOperator(new NumberExpression(8), new NumberExpression(0));
                result = divide.EvaluateExpression();
                Console.WriteLine(result);

            MultiplyOperator test = new MultiplyOperator(add, substract);
            result = test.EvaluateExpression();
            Console.WriteLine(result);*/

            #endregion

            Console.Title = "CLASSIC SCIENTIFIC CALCULATOR";
            Console.WriteLine("------ Welcome To Custom Scientific Calculator ------ \n");

            Program program = new Program();
            program.Run();
        }

        #region Launcher
        public void Run()
        {
            this.CalculatorUI.Run();
        }
        #endregion
    }
}
