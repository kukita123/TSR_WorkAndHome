using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {       
        static void AddDictionaryItems(Dictionary<int,string>countries)
        {
            countries.Add(1, "Bulgaria");
            countries.Add(3, "Great Britain");
            countries.Add(2, "USA");
            countries.Add(4, "France");
            countries.Add(5, "Russia");
        }

        static void DisplayDictionary(Dictionary<int, string> countries)
        {
            foreach (KeyValuePair<int, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }

        static void Main(string[] args)
        {
            Dictionary<int, string> countries = new Dictionary<int, string>(5);
            AddDictionaryItems(countries);

            DisplayDictionary(countries);

            // избор на елемент по ключ:
            string country = countries[4];//Russia
            // промяна на обект:
            countries[4] = "Spain";
            // изтриване по ключ
            countries.Remove(2);

            Console.WriteLine();
            DisplayDictionary(countries);

            Console.ReadKey();
        }
    }
}
