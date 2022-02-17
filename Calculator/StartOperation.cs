using System;
using System.Reflection;

namespace Calculator
{
    class StartOperation
    {

        public static void Start()
        {
            string input;
            double first = 0;
            string operand = null;
            bool validation = true;

            do
            {

                input = Console.ReadLine();
                char[] inputarray = input.ToCharArray();
                bool flag = false;
                double second = 0;
                foreach (var item in inputarray)
                {
                    if (item == '=') { break; }

                    if (item >= '0' && item <= '9')
                    {
                        if (flag == false)
                        {
                            if (first != 0) { first = first * 10 + Convert.ToDouble(item.ToString()); }
                            else { first = Convert.ToDouble(item.ToString()); }
                        }
                        else
                        {
                            if (second != 0) { second = second * 10 + Convert.ToDouble(item.ToString()); }
                            else { second = Convert.ToDouble(item.ToString()); }
                        }
                    }
                    else if (Validation(item))
                    { operand = item.ToString(); flag = true; }
                    else { Console.WriteLine("invalid operand input now");validation = false; }
                }
                if (validation)
                {
                    Calculator calculator = new Calculator();
                    first = calculator.Calculate(first, operand, second);
                    Console.WriteLine("result=" + first);
                }
            }
            while (input != "e");

        }


        public static bool Validation(char ch)
        {
            if (ch == '/' || ch == '*' || ch == '-' || ch == '+' || ch == '%')
                return true;
            else
                return false;
        }
        public static IOperation GetOperation(string operand)
        {
            Assembly assembly = null;
            dynamic instance = null;
            try
            {
                assembly = Assembly.LoadFrom(@"C:\Users\Toshiba\Desktop\CalculatorAddition\ModulOperation\ModulOperation\bin\Debug\net5.0\ModulOperation.dll");
                //  assembly = Assembly.LoadFrom("..//..//..//net5.0//ModulOperation.dll");

                Console.WriteLine("dll is created");
                Type type = assembly.GetType("ModulOperation.ModOperation");
                Console.WriteLine("type=" + type);

                instance = Activator.CreateInstance(type) as IOperation;


                // instance = new ModOperation();
                if (instance == null) { Console.WriteLine("instance is null"); }
                else { Console.WriteLine(" instance not null"); }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*       
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
                        case "%":
                            {
                                return instance;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("input valid operation");
                                break;
                            }
                    }*/
            return new AddOperation();

        }


    }
}
