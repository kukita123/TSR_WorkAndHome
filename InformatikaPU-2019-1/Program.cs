using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaPU_2019_1
{
    public enum Classification
    {
        HyperGiant=1,
        SuperGiant=2,
        BrightGiant=3,
        Giant=4,
        SubGiant=5,
        Dwarf=6,
        SubDwarf=7,
        RedDwarf=8,
        BrownDwarf=9
    }
        public class Star
    {
        public string name;
        public double distance;
        public Classification classify;
        public double weigth;
        public string constellation;

        private string StringLimmiter(string input, int maxLength)
        {
            if (input.Length < maxLength)
                return input;
            return input.Substring(0, maxLength - 1);            
        }
        public Star(string name, double distance, Classification classify, double weigth, string consellation)
        {
            this.name = StringLimmiter(name, 20);
            this.distance = distance;
            this.classify = classify;
            this.weigth = weigth;
            this.constellation = StringLimmiter(constellation, 30);
        }

    } 
    class Program
    {
        static void Main(string[] args)
        {
            int n = starsNumber();

            List<Star> stars = new List<Star>();
        }
        public static int starsNumber()
        {
            Console.WriteLine("Enter the number of stars - integer between 1 and 5000: ");
            int n = int.Parse(Console.ReadLine());

            while (n < 0 || n > 5000)
            {
                Console.WriteLine("Wrong number, enter again the number of stars - integer between 1 and 5000: ");
                n = int.Parse(Console.ReadLine());
            }

            return n;
        }

        public void EnterStars(List<Star> stars, int n)
        {
            Console.Write("Enter star's name:");
            string name = Console.ReadLine();

            // more code to be wriiten....
        }
    }
}
