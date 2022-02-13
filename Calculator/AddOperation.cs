using System;

namespace Calculator
{
    class AddOperation : IOperation
    {
        public double Operation<T>(T firstelement, T secondelement)
        {
            double dfirstelement = Convert.ToDouble(firstelement);
            double dsecondelement = Convert.ToDouble(secondelement);
            return dfirstelement + dsecondelement;
        }
    }
}
