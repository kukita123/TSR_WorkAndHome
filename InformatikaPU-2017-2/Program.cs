using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaPU_2017_2
{
    public struct Employe
    {
        public string ime;
        public string EGN;
        public string name;
        public string country;
        public string pCode;
        public string city;

        //custom constructor - using string limitation of the parameters
        public Employe(string ime, string EGN, string name, string country, string pCode, string city)
        {
            this.ime = StringLimit(ime, 50);
            this.EGN = StringLimit(EGN, 15);
            this.name = StringLimit(name, 50);
            this.country = StringLimit(country, 30);
            this.pCode = StringLimit(pCode, 30);
            this.city = StringLimit(city, 30);
        }

        private static string StringLimit(string input, int maxLength)
        {
            if (input.Length <= 50)
                return input;

            return input.Substring(0, maxLength);
        }

        public string DisplayEmploye()
        {
            return ime + ", " + EGN + ", " + name + ", " + country + ", " + city;
        }
    }


    class Program
    {
        //control the number of new objects
        public static int EmployesNumber()
        {
            Console.Write("Enter number of employes - integer between 1 and 50:");
            int n;
            n = int.Parse(Console.ReadLine());

            while (n < 1 || n > 50)
            {
                Console.WriteLine("Wrong number, try again!");
                Console.Write("Enter number of employes - integer between 1 and 50:");
                n = int.Parse(Console.ReadLine());
            }

            return n;
        }

        //using LINQ to sort the list
        public static List<Employe> SortByTwoFields(List<Employe> employe)
        {
            var sorted = employe.OrderBy(x => x.country).ThenBy(x => x.ime).ToList();
            return sorted;

        }

        public static List<Employe> SortByEGN(List<Employe> employe)
        {
            Employe temp;
            for (int i = 0; i < employe.Count - 1; i++)
            {
                for (int j = 0; j < employe.Count; j++)
                {
                    if (String.Compare(employe[i].EGN, employe[j].EGN) > 0)
                    {
                        temp = employe[i];
                        employe[i] = employe[j];
                        employe[j] = temp;
                    }
                }
            }
            return employe;
        }

        public static void GenerateEmail(List<Employe> employe)
        {
            foreach (var item in employe)
            {
                string[] names = item.name.Split(' ');
                string employeEmail;
                if (names.Length == 3)
                    employeEmail = names[2] + "_" + names[0] + "_" + names[1].Substring(0, 1) + "@nncomputers.com";
                else if (names.Length == 2)
                    employeEmail = names[1] + "_" + names[0] + "@nncomputers.com";
                else
                    employeEmail = names[0] + "@nncomputers.com";

                Console.WriteLine(item.ime + ", email: " + employeEmail);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Part 1:");

            int n = EmployesNumber();

            List<Employe> NewEmployes = new List<Employe>();

            //creating an object using the custom constructor and then adding it to the list:
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter ime:");
                string ime = Console.ReadLine();
                Console.Write("Enter EGN:");
                string EGN = Console.ReadLine();
                Console.Write("Enter name:");
                string name = Console.ReadLine();
                Console.Write("Enter country:");
                string country = Console.ReadLine();
                Console.Write("Enter pCode:");
                string pCode = Console.ReadLine();
                Console.Write("Enter city:");
                string city = Console.ReadLine();

                Employe employe = new Employe(ime, EGN, name, country, pCode, city);

                NewEmployes.Add(employe);
            }

            NewEmployes = SortByTwoFields(NewEmployes);

            Console.WriteLine();
            Console.WriteLine("Part 2:");
            foreach (var item in NewEmployes)
            {
                Console.WriteLine(item.DisplayEmploye());
            }

            Console.WriteLine();
            Console.WriteLine("Part 3:");
            NewEmployes = SortByEGN(NewEmployes);
            foreach (var item in NewEmployes)
            {
                if (item.ime.Length == 0 || item.EGN.Length == 0 || item.name.Length == 0 || item.country.Length == 0)
                    Console.WriteLine(item.DisplayEmploye());
            }

            Console.WriteLine();
            Console.WriteLine("Part 4:");
            GenerateEmail(NewEmployes);

            Console.ReadKey();
        }
    }
}
