using System;

namespace Calculator
{
    class StartOperation
    {

        public static void Start()
        {
            string input = null;
            do
            {
                input = Console.ReadLine();
                double first = Convert.ToDouble(input[0].ToString());
                string operand = input[1].ToString();
                double second = Convert.ToDouble(input[2].ToString());

                Func<string, IOperation> func = null;
                func +=GetOperation;
                Calculator calculator = new Calculator(func);
                calculator.Calculate(operand, first, second);
            }
            while (input != "e");

        }
        public static IOperation GetOperation(string operand)
        {
            switch (operand)
            {
                case "+":
                    {
                        return new AddOperation();
                    }
                case "-":
                    {
                        return new SubOperation();
                    }
                case "*":
                    {
                        return new MultiplyOperation();
                    }
                case "/":
                    {
                        return new DivideOperation();
                    }
                default:
                    {
                        Console.WriteLine("input valid operation");
                        break;
                    }
            }
            return new AddOperation();

        }


    }
}
