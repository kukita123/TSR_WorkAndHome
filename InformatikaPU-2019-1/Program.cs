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
        public string name { set; get; }
        public double distance { set; get; }
        public Classification classify { set; get; }
        public double weigth { set; get; }
        public string constellation { set; get; }

        private string StringLimmiter(string input, int maxLength)
        {
            if (input.Length < maxLength)
                return input;
            return input.Substring(0, maxLength - 1);            
        }//TO DO LIMITATION NUMBER OF AVAILABLE SIMBOLS ...........!!!

        public Star(string name, double distance, Classification classify, double weigth, string consтellation)
        {
            this.name = StringLimmiter(name, 20);
            this.distance = distance;
            this.classify = classify;
            this.weigth = weigth;
            this.constellation = StringLimmiter(consтellation, 30);
        } //TO DO CONSTRUCTOR ............ !!!
        
        public void DisplayObject()
        {
            Console.WriteLine("{0}, {1} св. г., {2}, {3} сл. м., {4}",this.name, this.distance, this.classify, this.weigth, this.constellation);
        }  //TO DO .....
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Part 1 -> Entering stars:");
            int n = starsNumber();

            List<Star> Stars = new List<Star>();

            #region Part 1 - entering stars
            //Part 1 - entering stars:
            for (int i = 0; i < n; i++)
            {
                EnterStar(Stars);
                // or:
                // Star star = EnterStar(); 
                // Stars.Add(star);
            }
            #endregion
            #region Part 2 - sorting stars by distance
            //Part 2 - sorting stars by distance
            Console.WriteLine();
            Console.WriteLine("Part 2 -> Sorted by distance stars:");
            SortByDistance(Stars);//Stars = SortByDistance(Stars);
            foreach (var item in Stars)
            {
                item.DisplayObject();
            }
            #endregion
            #region Part 2 - sorting stars by distance
            //Part 3 - sorting stars by two fields
            Console.WriteLine();
            Console.WriteLine("Part 3 -> Sorted by two fields stars:");
            var sorted = SortByTwoFields(Stars);
            foreach (var item in Stars)
            {
                item.DisplayObject();
            }
            #endregion
            #region Part 4 - sorting stars by two fields
            //Part 4 - sorting stars by two fields
            Console.WriteLine();
            Console.WriteLine("Part 4 -> Grouped stars, average weight:");
            AverageConstWeight(Stars);
            #endregion

            Console.ReadKey();
        }

        public static int starsNumber()//TO DO - LIMIT THE STARS NUMBER - INTEGER NUMBER BETWEEN 1 AND 2000
        {
            Console.WriteLine("Enter the number of stars - integer between 1 and 2000: ");
            int n = int.Parse(Console.ReadLine());

            while (n < 0 || n > 2000)
            {
                Console.WriteLine("Wrong number, enter again the number of stars - integer between 1 and 2000: ");
                n = int.Parse(Console.ReadLine());
            }

            return n;
        }  

        public static void EnterStar(List<Star> stars)// or: static Star EnterStar()
        {            
            Console.Write("Enter star's name:");
            string name = Console.ReadLine();

            double distance;
            do
            {
                Console.Write("Enter distance from Earth - positive double value: ");
                distance = double.Parse(Console.ReadLine());
            }
            while (distance <= 0);//TO DO - DOUBLE >0

            int clsf;
            do
            {
                Console.Write("Enter star's classyfication - integer between 1 and 9:");
                clsf = int.Parse(Console.ReadLine());
            }
            while (clsf < 1 || clsf > 9); //TO DO - LIMIT CLASSIFICATIONS IN BETWEEN 1-9

            double weigth;
            do
            {
                Console.Write("Enter star's weigth - positive double value: ");
                weigth = double.Parse(Console.ReadLine());
            }
            while (weigth <= 0);//TO DO - DOUBLE > 0

            Console.Write("Enter star's consтellation:");
            string consтellation = Console.ReadLine();

            Star star = new Star(name, distance, (Classification)clsf, weigth, consтellation); //create a star using constructor
            stars.Add(star); // or: return star;
        } //TO DO .... //Starsn

        public static void SortByDistance(List<Star> stars)  //classic bubble sort  // or: public static List<Star> SortBydistList<Star>stars){... return stars;}
        {
            for (int i = 0; i < stars.Count; i++)
            {
                for (int j = 0; j < stars.Count - 1; j++)
                {
                    if (stars[j].distance > stars[j+1].distance)  
                    {
                        Star temp = stars[j];
                        stars[j] = stars[j + 1];
                        stars[j + 1] = temp;
                    }
                }
            }
        }

        public static List<Star> SortByTwoFields(List<Star> stars)
        {
            var sorted = stars
                .OrderBy(x => x.name)
                .ThenByDescending(x => x.weigth)
                .ToList<Star>();
            return sorted;
        } //TO DO USING LINQ

        public static void AverageConstWeight(List<Star>stars)
        {
            var groupedStars = stars.GroupBy(x => x.constellation);

            foreach (var group in groupedStars)
            {
                Console.WriteLine("Constellation {0} - > average weight {1}", group.Key, group.Average(x=>x.weigth));
            }
        }  //TO DO USING LINQ        
    }
}
/* Данни за тест:
5
Проксима Кентавър
4,24
8
0,122
Кентавър
Алфа Кентавър
4,36
6
1,1
Кентавър
Бетелгейзе
700
2
22
Орион
Цефей
9000
1
202
Цефей
Белатрикс
250
4
8,6
Орион
*/
