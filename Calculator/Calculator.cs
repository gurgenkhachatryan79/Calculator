using System;

namespace Calculator
{
    class Calculator
    {
        private Func<string, IOperation> _myoperation;
        public Calculator(Func<string, IOperation> myoperation)
        {
            _myoperation = myoperation;
        }
        public double Calculate<T>(string str, T number1, T number2)
        {
            IOperation operation = _myoperation(str);
            double result = operation.Operation(number1, number2);
            Console.WriteLine("result=" + result);
            return result;
        }
    }
}
