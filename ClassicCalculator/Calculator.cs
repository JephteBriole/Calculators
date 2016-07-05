using ClassicCalculator.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalculator
{
    class Calculator
    {
        public Expression CurrentValue { get; set; }

        #region Calculator's Logic
        public void Clear()
        {
            this.CurrentValue = null;
            Console.Clear();
            Console.WriteLine("------ Welcome To Custom Scientific Calculator ------ \n");
        }
        #endregion
    }
}
