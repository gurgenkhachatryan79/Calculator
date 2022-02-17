using System;

namespace Calculator
{
    class SubOperation : IOperation
    {
        public double Operation(double firstelement, double secondelement)
        {
            return firstelement - secondelement;
        }
    }
}
