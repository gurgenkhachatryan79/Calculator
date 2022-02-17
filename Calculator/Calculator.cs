using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace Calculator
{
    class Calculator : ICalculator
    {
        public Dictionary<string, IOperation> baseOperation;

        public Calculator()
        {
            baseOperation = new Dictionary<string, IOperation>();
            baseOperation.Add("+", new AddOperation());
            baseOperation.Add("-", new SubOperation());
            baseOperation.Add("*", new MultiplyOperation());
            baseOperation.Add("/", new DivideOperation());
            AddCustomOperations();
        }

        public double Calculate(double first, string operand, double second)
        {
            IOperation currentOperation = baseOperation[operand];                
                return  currentOperation.Operation(first, second); 
        }

        public void AddCustomOperations()
        {
            Assembly assembly = null;
            IOperation instance ;
            try
            {
                assembly = Assembly.LoadFrom(@"C:\Users\Toshiba\Desktop\CalculatorAddition\ModulOperation\ModulOperation\bin\Debug\net5.0\ModulOperation.dll");
                //  assembly = Assembly.LoadFrom("..//..//..//net5.0//ModulOperation.dll");
                Type type = assembly.GetType("ModulOperation.ModOperation");
                Console.WriteLine("type=" + type);
                instance = Activator.CreateInstance(type) as IOperation;
                baseOperation.Add("%",instance);
                if (instance == null) { Console.WriteLine("instance is null"); }
                else { Console.WriteLine(" instance not null"); }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
