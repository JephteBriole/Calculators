using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    class CalculatorUI
    {
        private Calculator _calculator;

        #region Properties
        private string Input { get; set; } = "";
        private bool ExitFlag { get; set; }
        private bool IsCommand { get; set; }
        #endregion

        #region Constructor
        public CalculatorUI(Calculator calculator)
        {
            this.ExitFlag = false;
            this._calculator = calculator;
        }
        #endregion

        #region Computation Launcher
        public void Run()
        {
            while (!ExitFlag)
            {
                Console.Write("RPN Calculator > ");
                string userInput = Console.ReadLine().TrimStart().TrimEnd();

                if (!string.IsNullOrEmpty(userInput) && IsValidInput(userInput) && !IsCommand)
                {
                    this.Input += " " + userInput ;
                    this.ParseExpression();
                }
            }
        }
        #endregion

        #region User Input Validation / Tokenization

        #region Validation
        private bool IsValidInput(string input)
        {
            double tmpDouble;
            var operands = input.Split(' ');
            this.IsCommand = false;

            if (operands.Length == 1 && !double.TryParse(input, out tmpDouble))
            {
                this.IsCommand = true;
                return this.IsValidCommand(operands[0]);
            }

            return true;
        }
        private bool IsValidCommand(string command)
        {
            bool isValid = true;

            switch (command.ToLower())
            {
                case "clear":
                    this._calculator.Clear();
                    this.Input = string.Empty;

                    break;
                case "quit":
                    this.ExitFlag = true;

                    break;
                case "help":
                    Console.WriteLine("\n****************** Help Interface ******************\n");
                    Console.WriteLine("Commands : ");
                    Console.WriteLine("\t clear : To reinitialize the calculator");
                    Console.WriteLine("\t quit  : To quit the calculator");
                    Console.WriteLine("\t help  : To display this Help Interface");
                    Console.WriteLine("\n****************************************************\n");

                    break;
                default:
                    if (string.IsNullOrEmpty(this.Input))
                    {
                        Console.WriteLine("RPN Calculator > Command Not Valid !\n");
                        isValid = false;
                    }

                    break;
            }

            return isValid;
        }
        #endregion

        #region Tokenization
        private void ParseExpression()
        {
            double tmp = 0;
            string[] expression = this.Input.Split(' ');

            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case "*":
                        this._calculator.Multiply();
                        break;
                    case "/":
                        this._calculator.Divide();
                        break;
                    case "-":
                        this._calculator.Substract();
                        break;
                    case "+":
                        this._calculator.Add();
                        break;
                    default:
                        if (double.TryParse(expression[i], out tmp))
                            this._calculator.Push(double.Parse(expression[i]));
                        break;
                }
            }

            this.Display();
        }
        #endregion

        #region Display Result
        private void Display()
        {
            Console.WriteLine("RPN Calculator > {0} = {1}\n", this.Input.TrimStart(), !string.IsNullOrEmpty(this._calculator.ErrorString) ? double.NaN.ToString() + " : " + this._calculator.ErrorString : string.Join(" | ", this._calculator.operands.Reverse()));
            this._calculator.operands.Clear();

            // Clear the stack if Error 
            if (!string.IsNullOrEmpty(this._calculator.ErrorString))
            {
                this.Input = string.Empty;
                this._calculator.ErrorString = string.Empty;
            }
        }
        #endregion

        #endregion
    }
}
