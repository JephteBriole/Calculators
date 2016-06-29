using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalculator
{
    public enum TknType
    {
        Tkn_Number = 1,
        Tkn_Add = 2,
        Tkn_Sub = 3,
        Tkn_Mult = 4,
        Tkn_Div = 5,
        Tkn_OpenParenth = 6,
        Tkn_CloseParenth = 7
    }
    public struct Token
    {
        public string _value;
        public TknType _type;
    }

    public class Tokenizer
    {
        public List<Token> Tokenize(string userInput)
        {
            double tmpDouble;
            List<Token> tokens = new List<Token>();

            string[] expression = Normalize(userInput);
            
            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case "*":
                        tokens.Add(new Token() { _value = expression[i], _type = TknType.Tkn_Mult });
                        break;
                    case "/":
                        tokens.Add(new Token() { _value = expression[i], _type = TknType.Tkn_Div });
                        break;
                    case "-":
                        tokens.Add(new Token() { _value = expression[i], _type = TknType.Tkn_Sub });
                        break;
                    case "+":
                        tokens.Add(new Token() { _value = expression[i], _type = TknType.Tkn_Add });
                        break;
                    case "(":
                        tokens.Add(new Token() { _value = expression[i], _type = TknType.Tkn_OpenParenth });
                        break;
                    case ")":
                        tokens.Add(new Token() { _value = expression[i], _type = TknType.Tkn_CloseParenth});
                        break;
                    default:
                        if (double.TryParse(expression[i], out tmpDouble))
                            tokens.Add(new Token() { _value = expression[i], _type = TknType.Tkn_Number });
                        else
                        {
                            throw new Exception(string.Format("Calculator > {0} Is Not a Valid Token !", expression[i]));
                        }
                        break;
                }
            }

            Console.WriteLine();
            foreach(Token tk in tokens)
            {
                Console.WriteLine("Token : {0} ----- Type : {1}", tk._value, tk._type);
            }

            return tokens;
        }

        #region User Input Normalization Delegate
        private string[] Normalize(string userInput)
        {
            List<string> expr = new List<string>();
            foreach (var item in userInput.Split(' '))
            {
                if (item.StartsWith("("))
                {
                    expr.Add("(");
                    string newItem = item.Replace("(", "");
                    expr.Add(newItem);
                }



                else if (item.EndsWith(")"))
                {
                    string newItem = item.Replace(")", "");
                    expr.Add(newItem);
                    expr.Add(")");
                }
                else if (item.Contains("("))
                {
                    expr.AddRange(item.Split('('));
                }
                else if (item.Contains(")"))
                {
                    expr.AddRange(item.Split(')'));
                }
                else
                    expr.Add(item);
            }

            return expr.ToArray();
        }
        #endregion
    }
}
