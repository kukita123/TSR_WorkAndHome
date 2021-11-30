using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingAppsEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6};
            var smallest = GetSomeSmallests(numbers, 3);

            foreach (var item in smallest)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey(); 
        }
        public static List<int>GetSomeSmallests(List<int>list,int count)
        {
            var smallest = new List<int>();

            while (smallest.Count < count)
            {
                var min = GetSmallest(list);
                smallest.Add(min);
                list.Remove(min);
            }

            return smallest;
        }
        public static int GetSmallest(List<int> list)
        {
            var min = list[0];

            for (int i = 1 ; i < list.Count; i++)
            {
                if (list[i] > min)
                    min = list[i];
            }

            return min;
        }
    }
}
