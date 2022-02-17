using System;

namespace Calculator
{
    class AddOperation : IOperation
    {
        public double Operation(double firstelement, double secondelement)
        {
            return firstelement + secondelement;
        }
    }
}
