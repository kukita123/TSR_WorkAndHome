using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingApplications
{



    class Program
    {
        static void Main(string[] args)
        {
            Calculator result = new Calculator();
            var sum = result.Sum(2, 3);

            Console.WriteLine("The result is: {0}", sum);

            Console.ReadKey();
        }
    }
}
