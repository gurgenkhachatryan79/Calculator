using System;

namespace Calculator
{
    class MultiplyOperation : IOperation
    {
        public double Operation(double firstelement, double secondelement)
        {
            return firstelement * secondelement;
        }
    }
}
