using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSR_WorkAndHome
{
    class Program
    {
        enum Operation
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide
        }

        static void MathOp(double x, double y, Operation op)
        {
            double result = 0.0;

            switch (op)
            {
                case Operation.Add:
                    result = x + y;
                    break;

                case Operation.Subtract:
                    result = x - y;
                    break;

                case Operation.Multiply:
                    result = x * y;
                    break;

                case Operation.Divide:
                    result = x / y;
                    break;
            }

            Console.WriteLine("Резултат от операция {0} на {1} и {2} равен на {3}",op, x, y, result);
        }

        static void Main(string[] args)
        {
            Operation op;
            op = Operation.Add;
            Console.WriteLine(op); // Add


            // Тип на операцията задаваме с помощта на константа Operation.Add, равна 1:
            MathOp(10, 5, Operation.Add);

            // Типът на операцията задаваме с помощта на константа Operation.Multiply, равна 3:
            MathOp(11, 5, Operation.Multiply);

            EnumDemo.EnumsTest();

            Console.ReadKey();
        }
    }
}
