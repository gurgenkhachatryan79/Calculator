using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class DivideOperation : IOperation
    {
        public double Operation(double firstelement, double secondelement)
        {
            if (secondelement == 0)
            {
                Console.WriteLine("the number cannot be divided by 0");
                throw new DivideByZeroException();
            }
            return firstelement / secondelement;
        }
    }
}
