using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class DivideOperation : IOperation
    {
        public double Operation<T>(T firstelement, T secondelement)
        {
            double dfirstelement = Convert.ToDouble(firstelement);
            double dsecondelement = Convert.ToDouble(secondelement);
            if (dsecondelement == 0)
            {
                Console.WriteLine("the number cannot be divided by 0");
                throw new DivideByZeroException();
            }
            return dfirstelement / dsecondelement;
        }
    }
}
