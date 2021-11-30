using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryExersice
{
    class Program
    {
        static string OddNumberWordsCount(string input)
        {
            input = input.ToLower();

            string[] words = input.Split(' ');

            //dictionary - every word is the key, the count of thos word is the value:
            Dictionary<string, int> couples = new Dictionary<string, int>();

            //loop to fill the couples dictionary:
            foreach (var item in words)
            {
                if (couples.ContainsKey(item))
                    couples[item]++;
                else
                    couples.Add(item, 1);
            }

            //list to store the odd count words - it's value is an odd number, and we store the key in the list
            List<string> result = new List<string>();

            //loop to fill the result list (if the valie is an odd number, we add the key in the list):
            foreach (var pair in couples)
            {
                if (pair.Value % 2 != 0)
                    result.Add(pair.Key);                  
            }

            return string.Join(" ",result);            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter string:");
            string input = Console.ReadLine();

            Console.WriteLine(OddNumberWordsCount(input)); 

            Console.ReadKey();
        }
    }
}
//trite imena egn adres 