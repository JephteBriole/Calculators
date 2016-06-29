using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    class Program
    {
        private Calculator Calculator { get; set; }
        private CalculatorUI CalculatorInput { get; set; }

        #region Constructor
        public Program()
        {
            this.Calculator = new Calculator();
            this.CalculatorInput = new CalculatorUI(Calculator);
        }
        #endregion

        #region Launcher
        public void Run()
        {
            this.CalculatorInput.Run();
        } 
        #endregion
        static void Main(string[] args)
        {
            Console.Title = "RPN CALCULATOR";
            Console.WriteLine("------ Welcome To Custom RPN Calculator ------ \n");

            Program program = new Program();
            program.Run();
        }
    }
}
