using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSR_WorkAndHome
{
    // Деклариране на изброяване:
    enum Animals
    {
        Cat,
        Dog,
        Fox,
        Wolf,
        Bear
    };

    // Деклариране на изброяване с инициализация на константи:
    enum Coins { One = 1, Two, Five = 5, Ten = 10, Fifty = 50 };

    enum Weekday { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

    class EnumDemo
    {
        public static void EnumsTest1()
        {
            Console.WriteLine("В света на животните");
            // Променлива от тип изброяване:
            Animals animal = Animals.Cat;
            Console.WriteLine("animal: {0,-5} или {1}", animal, (int)animal);

            // Нова стойност на променливата:
            animal = Animals.Dog;
            Console.WriteLine("animal: {0,-5} или {1}", animal, (int)animal);

            // Преобразуване на цяло число в стойност от тип
            // изброяване:
            animal = (Animals)2;
            Console.WriteLine("animal: {0,-5} или {1}", animal, (int)animal);

            // Сума на променлива и цяло число:
            animal = animal + 1;
            Console.WriteLine("animal: {0,-5} или {1}", animal, (int)animal);

            // Инкрементиране:
            animal++;
            Console.WriteLine("animal: {0,-5} или {1}", animal, (int)animal);


            Console.WriteLine("В света на финансите");
            // Променлива от тип на изброяване:
            Coins coin;

            // Обект с константи от изброяване:
            // !!! Обърнете внимание на начина на създаване на масива names - с използване на метод GetValues и typeof
            Array names = Enum.GetValues(typeof(Coins));

            // Обхождане на константите:
            for (int i = 0; i < names.Length; i++)
            {
                // Стойност на променливата:
                coin = (Coins)names.GetValue(i);
                Console.WriteLine("coin: {0,-5} или {1}", coin, (int)coin);
            }
        }        

        public static void EnumTest2()
        {
            Weekday Day ;
            double sum = 0;
            for (Day = Weekday.Sunday; Day <= Weekday.Saturday; Day=(Weekday)(Day+1))
            {
                Console.WriteLine("Enter average daily temperature: ");
                double t = double.Parse(Console.ReadLine());
                sum += t;
            }
            Console.WriteLine("Average weekly temperature: "+sum/7);

        }
    

    }
}
