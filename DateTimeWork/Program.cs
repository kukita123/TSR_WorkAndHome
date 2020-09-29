using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeWork
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime date1 = new DateTime();
            Console.WriteLine(date1); // 01.01.0001 0:00:00
            Console.WriteLine(DateTime.MinValue);// 01.01.0001 0:00:00

            DateTime date2 = new DateTime(2020, 7, 20); // година - месец - ден
            Console.WriteLine(date2); // 20.07.2020 0:00:00

            DateTime date3 = new DateTime(2020, 7, 20, 18, 30, 25); // година - месец - ден - час - минута - секунда
            Console.WriteLine(date3); // 20.07.2020 18:30:25

            Console.WriteLine("\nТекущи ден и час, време по Гринуич:");
            Console.WriteLine(DateTime.Now);// текуща дата и час на компютъра
            Console.WriteLine(DateTime.UtcNow+" GMT");// дата и час по Гринуич (GMT)
            Console.WriteLine(DateTime.Today);// текуща дата


            Console.WriteLine("\nДобавяне на 3 часа:");
            DateTime date = new DateTime(2020, 7, 20, 18, 30, 25); // 20.07.2020 18:30:25
            Console.WriteLine(date.AddHours(3)); // 20.07.2020 21:30:25

            Console.WriteLine("\nВадене на дати:");
            DateTime date4 = new DateTime(2020, 7, 20, 18, 30, 25); // 20.07.2020 18:30:25
            DateTime date5 = new DateTime(2020, 7, 20, 15, 30, 25); // 20.07.2020 15:30:25
            Console.WriteLine(date4.Subtract(date5)); // 03:00:00


            Console.WriteLine("\nИзваждане на три часа:");
            // изваждане на три часа
            DateTime date6 = new DateTime(2020, 7, 20, 18, 30, 25);  // 20.07.2020 18:30:25
            Console.WriteLine(date6.AddHours(-3)); // 20.07.2020 15:30:25

            Console.WriteLine("\nВарианти на форматиране:");
            date1 = new DateTime(2020, 7, 20, 18, 30, 25);
            Console.WriteLine(date1.ToLocalTime()); // 20.07.2020 21:30:25
            Console.WriteLine(date1.ToUniversalTime()); // 20.07.2020 15:30:25
            Console.WriteLine(date1.ToLongDateString()); // 20 юли 2020 г.
            Console.WriteLine(date1.ToShortDateString()); // 20.07.2020
            Console.WriteLine(date1.ToLongTimeString()); // 18:30:25
            Console.WriteLine(date1.ToShortTimeString()); // 18:30

            Console.ReadKey();
        }
    }
}
