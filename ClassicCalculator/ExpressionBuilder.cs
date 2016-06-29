using ClassicCalculator.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalculator
{
    class ExpressionBuilder
    {
        private Calculator _calculator;
        private readonly string[] _operators;

        #region Properties
        private bool IsCommand { get; set; }
        private string UserInput { get; set; }
        private Expression Expression { get; set; }
        public bool ExitFlag { get; set; } 
        #endregion
        public ExpressionBuilder()
        {
            this.ExitFlag = false;
            this._calculator = new Calculator();
        }

        public Expression ParseExpression(string userInput)
        {
            if (!string.IsNullOrEmpty(userInput) && IsValidInput(userInput) && !IsCommand)
            {
                //this.UserInput += " " + userInput;
                this.UserInput = userInput;
                var tokens = new Tokenizer().Tokenize(this.UserInput);

                this.ParseExpression();
            }
            return null;
        }

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
                    this.UserInput = string.Empty;

                    break;
                case "quit":
                case "exit":
                    this.ExitFlag = true;

                    break;
                case "help":
                case "?":
                    Console.WriteLine("\n****************** Help Interface *********************\n");
                    Console.WriteLine("Commands : ");
                    Console.WriteLine("\t clear       : To reinitialize the calculator");
                    Console.WriteLine("\t quit / exit : To quit the calculator");
                    Console.WriteLine("\t help / ?    : To display this Help Interface");
                    Console.WriteLine("\n*******************************************************\n");

                    break;
                default:
                    Console.WriteLine("Calculator > Command Not Valid !\n");
                    isValid = false;

                    break;
            }

            return isValid;
        }
        #endregion

        #region Expression Formatting
        private void ParseExpression()
        {
            double tmp = 0;
            string[] expression = this.UserInput.Split(' ');

            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                { case "*":
                        break;
                    case "/":
                        break;
                    case "-":
                        break;
                    case "+":
                        break;
                    case "(":
                        break;
                    case ")":
                        break;
                    default:
                        break;
                   
                }
            }
        }
        #endregion

        #region Display Result
        public void Display()
        {
            DataTable dt = new DataTable();
            double result = double.Parse(dt.Compute(this.UserInput, " ").ToString());
            Console.WriteLine("Calculator > {0} = {1}\n", this.UserInput, result/*this.Expression.EvaluateExpression()*/);
        }
        #endregion

        #endregion
    }
}
