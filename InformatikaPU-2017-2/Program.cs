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
        public static int EmployesNumber()
        {
            Console.Write("Enter number of employes - integer between 1 and 50:");
            int n;
            n = int.Parse(Console.ReadLine());

            while(n < 1 || n > 50)
            {
                Console.WriteLine("Wrong number, try again!");
                Console.Write("Enter number of employes - integer between 1 and 50:");
                n = int.Parse(Console.ReadLine());
            }

            return n;
        }
        static void Main(string[] args)
        {
            int n = EmployesNumber();

            List<Employe> NewEmployes = new List<Employe>();

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

                Employe employe = new Employe(ime,EGN,name,country,pCode,city);

                NewEmployes.Add(employe);
            }

            foreach (var item in NewEmployes)
            {
                Console.WriteLine(item.DisplayEmploye()); 
            }

            Console.ReadKey();
        }
    }
}
