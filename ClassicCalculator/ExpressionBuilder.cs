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
        private Tokenizer _tokenizer;

        #region Properties
        private bool IsCommand { get; set; }
        public string UserInput { get; set; }
        private Expression Expression { get; set; }
        public bool ExitFlag { get; set; } 
        #endregion
        public ExpressionBuilder()
        {
            this.ExitFlag = false;
            this._calculator = new Calculator();
            this._tokenizer = new Tokenizer();
        }

        public Expression ParseExpression()
        {
            if (!string.IsNullOrEmpty(this.UserInput) && IsValidInput(this.UserInput) && !IsCommand)
            {
                this.ParseExpression(this._tokenizer.Tokenize(this.UserInput));
            }
            return null;
        }

        #region User Input Validation / Tokenization

        private Expression GetExpression()
        {
            return null;
        }

        private Expression ParseExpression(IEnumerable<Token> tokens)
        {
            Expression leftOperand;
            Expression rightOperand;
            int iterator = 0;

            foreach (var token in tokens)
            {
                switch(token._type)
                {
                    case TknType.Tkn_Number:
                        leftOperand = new NumberExpression(double.Parse(token._value));
                        break;
                    case TknType.Tkn_Add:
                        var newTokens = tokens.ToList().GetRange(iterator, tokens.Count() - 1);
                        rightOperand = this.ParseExpression(newTokens);
                        break;
                    case TknType.Tkn_Sub:

                        break;
                    case TknType.Tkn_Mult:

                        break;
                    case TknType.Tkn_Div:
                        break;
                    case TknType.Tkn_OpenParenth:
                        break;
                }

                iterator++;

                //Console.WriteLine("Token : {0} <--> Type : {1}", token._value, token._type);
            }
            return null;
        }

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

        //#region Expression Formatting
        //private void ParseExpression()
        //{
        //    double tmp = 0;
        //    string[] expression = this.UserInput.Split(' ');

        //    for (int i = 0; i < expression.Length; i++)
        //    {
        //        switch (expression[i])
        //        { case "*":
        //                break;
        //            case "/":
        //                break;
        //            case "-":
        //                break;
        //            case "+":
        //                break;
        //            case "(":
        //                break;
        //            case ")":
        //                break;
        //            default:
        //                break;
                   
        //        }
        //    }
        //}
        //#endregion

        #region Display Result
        public void Display()
        {
            DataTable dt = new DataTable();
            double result = double.Parse(dt.Compute(this.UserInput, " ").ToString());
            Console.WriteLine("Calculator > Result = {0}\n", result/*this.Expression.EvaluateExpression()*/);
        }
        #endregion

        #endregion
    }
}
