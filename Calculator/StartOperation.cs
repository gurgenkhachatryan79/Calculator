using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Calculator
{
    class StartOperation
    {

        public static void Start()
        {
            string input = null;
            double first = 0;
            string operand = null;

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
                    else
                    { operand = item.ToString(); flag = true; }

                }
                Func<string, IOperation> func = null;
                //   List<IOperation> operations=null;
                //   var operation= GetOperation(operand);
                //    operations.Add(operation);     
                func += GetOperation;
                Calculator calculator = new Calculator(func);
                first = calculator.Calculate(operand, first, second);
            }
            while (input != "e");

        }

        public static IOperation GetOperation(string operand)
        {
            Assembly assembly = null;
            IOperation instance = null;
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
            }
            return new AddOperation();

        }


    }
}
