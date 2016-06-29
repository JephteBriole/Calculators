using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    class Calculator
    {
        private double CurrentValue { get; set; }
        public string ErrorString { get; set; } = string.Empty;
        public Stack<double> operands = new Stack<double>();

        #region Calculator Engine
        public void Clear()
        {
            operands.Clear();

            Console.Clear();
            Console.WriteLine("------ Welcome To Custom RPN Calculator ------ \n");

            this.ErrorString = string.Empty;
        }
        public void Push(double operand)
        {
            operands.Push(operand);
        }
        public void Add()
        {
            double x; //first operand
            double y; //second operand

            #region Try Computing "+"
            try
            {
                y = operands.Pop();
                x = operands.Pop();

                CurrentValue = x + y;
                operands.Push(CurrentValue);
            }
            catch (Exception)
            {
                ErrorString = "[ERROR] Expression / Operation Not Valid : Check if the operators are well placed !";
            }
            #endregion
        }
        public void Substract()
        {
            double x; //first operand
            double y; //second operand

            #region Try Computing "-"
            try
            {
                y = operands.Pop();
                x = operands.Pop();

                CurrentValue = x - y;
                operands.Push(CurrentValue);
            }
            catch (Exception)
            {
                ErrorString = "[ERROR] Expression Not Valid : Check if the operators are well placed !";
            }
            #endregion
        }
        public void Multiply()
        {
            double x; //first operand
            double y; //second operand

            #region Try Computing "*"
            try
            {
                y = operands.Pop();
                x = operands.Pop();

                CurrentValue = x * y;
                operands.Push(CurrentValue);
            }
            catch (Exception)
            {
                ErrorString = "[ERROR] Expression Not Valid : Check if the operators are well placed !";
            }
            #endregion
        }
        public void Divide()
        {
            double x; //first operand
            double y; //second operand

            #region Try Computing "/"
            try
            {
                y = operands.Pop();
                x = operands.Pop();

                CurrentValue = y != 0 ? x / y : double.NaN;
                operands.Push(CurrentValue);
            }
            catch (Exception)
            {
                ErrorString = "[ERROR] Expression Not Valid : Check if the operators are well placed !";
            }
            #endregion
        }
        #endregion
    }
}
