using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    interface ICalculator
    {
      //  Dictionary<string, IOperation> baseOperation { get; set; }
        double Calculate(double first, string operand, double second);

    }
}
