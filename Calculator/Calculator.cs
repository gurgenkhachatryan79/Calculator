using System;
using System.Collections.Generic;

namespace Calculator
{
    class Calculator
    {
        private Func<string, IOperation> _myoperation;
      //  private readonly IEnumerable<IOperation> _myoperations;
        //private List<string> _operations;

        public Calculator(Func<string, IOperation> myoperation)
        //  public Calculator(IEnumerable<IOperation> myoperations)  
        {
            _myoperation = myoperation;
        }
        public double Calculate(string str, double number1, double number2)
        {
          
            IOperation operation= _myoperation(str);
            double result = operation.Operation(number1, number2);
            Console.WriteLine("result=" + result);
            return result;
        }
    }
}
