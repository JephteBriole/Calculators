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
        Tkn_Add,
        Tkn_Sub,
        Tkn_Mult,
        Tkn_Div,
        Tkn_OpenParenth,
        Tkn_CloseParenth 

    }
    public struct Token
    {
        public string _value;
        public TknType _type;
    }

    public class Tokenizer
    {
        public IEnumerable<Token> Tokenize(string userInput)
        {
            double tmpDouble;
            int iterator = 0;
            userInput = userInput.Replace(" ", "");

            while (iterator < userInput.Length)
            {
                Token token = new Token();

                
                switch (userInput[iterator])
                {
                    case '*':
                        token._value += userInput[iterator].ToString();
                        token._type = TknType.Tkn_Mult;
                        iterator++;
                        break;
                    case '/':
                        token._value += userInput[iterator].ToString();
                        token._type = TknType.Tkn_Div;
                        iterator++;
                        break;
                    case '-':
                        token._value += userInput[iterator].ToString();
                        token._type = TknType.Tkn_Sub;
                        iterator++;
                        break;
                    case '+':
                        token._value += userInput[iterator].ToString();
                        token._type = TknType.Tkn_Add;
                        iterator++;
                        break;
                    case '(':
                        token._value += userInput[iterator].ToString();
                        token._type = TknType.Tkn_OpenParenth;
                        iterator++;
                        break;
                    case ')':
                        token._value += userInput[iterator].ToString();
                        token._type = TknType.Tkn_CloseParenth;
                        iterator++;
                        break;
                    default:
                        while (iterator < userInput.Length && double.TryParse(userInput[iterator].ToString(), out tmpDouble))
                        {
                            token._value += userInput[iterator].ToString();
                            token._type = TknType.Tkn_Number;
                            iterator++;
                        }
                        break; 
                }
                
                yield return token;
            }
        }

        //#region User Input Normalization Delegate
        //private string[] Normalize(string userInput)
        //{
        //    List<string> expr = new List<string>();
        //    foreach (var item in userInput.Split(' '))
        //    {
        //        if (item.StartsWith("("))
        //        {
        //            expr.Add("(");
        //            string newItem = item.Replace("(", "");
        //            expr.Add(newItem);
        //        }



        //        else if (item.EndsWith(")"))
        //        {
        //            string newItem = item.Replace(")", "");
        //            expr.Add(newItem);
        //            expr.Add(")");
        //        }
        //        else if (item.Contains("("))
        //        {
        //            expr.AddRange(item.Split('('));
        //        }
        //        else if (item.Contains(")"))
        //        {
        //            expr.AddRange(item.Split(')'));
        //        }
        //        else
        //            expr.Add(item);
        //    }

        //    return expr.ToArray();
        //}
        //#endregion
    }
}
