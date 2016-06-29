﻿using ClassicCalculator.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCalculator
{
    class Calculator
    {
        private Expression CurrentValue { get; set; }
        public string ErrorString { get; set; }

        #region Calculator's Logic
        public void Clear()
        {
            this.CurrentValue = null;
            Console.Clear();
            Console.WriteLine("------ Welcome To Custom Scientific Calculator ------ \n");

            this.ErrorString = string.Empty;
        }
        #endregion
    }
}