using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformatikaPU_2019_2
{
    struct Client
    {
        private static string StringLimitter(string input)
        {
            if (input.Length <= 40)
                return input;
            return input.Substring(0, 40);
        }

        private string name;
        private DateTime registrationDate;
        private int purchasesNumber;
        private double purchasesSum;
        private int rating;

        public Client(string name, string regDate, int purchNumber, double purchSum, int rating)
        {
            this.name = StringLimitter(name);
            this.registrationDate = Convert.ToDateTime(regDate);
            this.purchasesNumber = purchNumber;
            this.purchasesSum = purchSum;
            this.rating = rating;
        }

        public string PrintClient()
        {
            string stars;

            switch (Rating)
            {
                case 1: stars = "*"; break;
                case 2: stars = "**"; break;
                case 3: stars = "***"; break;
                case 4: stars = "****"; break;
                case 5: stars = "*****"; break;
                default: stars = ""; break;
            }

            return this.Name + 
                ", " + this.purchasesNumber + 
                ", " + Math.Round(this.purchasesSum,2)+ 
                ", " + this.registrationDate.ToShortDateString()+ 
                ", "+ stars;
        }

        public string Name
        {
            get { return this.name; }
            set { name = StringLimitter(value); }
        }
        public double PurchasesSum
        {
            get { return this.purchasesSum; }
        }
        public int Rating
        {
            get { return this.rating; }
        }
        public int RegistrationYear()
        {
            return this.registrationDate.Year;
        }
    }
    class Program
    {
        static int ClientsNumbers()
        {
            int n;
            do
            {
                Console.Write("Enter number of clients:");
                n = int.Parse(Console.ReadLine());
            }
            while (n < 1 || n > 5000);
            return n;
        }

        static int PurchasesNumber()
        {
            int n;
            do
            {
                Console.Write("Enter number of purchases:");
                n = int.Parse(Console.ReadLine());
            }
            while (n < 1 || n > 9999);
            return n;
        }

        public static int ClientsRating()
        {
            int n;
            do
            {
                Console.Write("Enter client's rating: ");
                n = int.Parse(Console.ReadLine());
            }
            while (n < 1 || n > 5);
            return n;
        }

        public static List<Client> SortByName(List<Client> Clients)
        {
            for (int i = 0; i < Clients.Count-1; i++)
            {
                for (int j = i+1; j < Clients.Count; j++)
                {
                    if(String.Compare(Clients[i].Name, Clients[j].Name) > 0)
                    {
                        Client temp = Clients[i];
                        Clients[i] = Clients[j];
                        Clients[j] = temp;
                    }
                }
            }
            return Clients;
        }

        public static List<Client> SortAndFilter(List<Client> Clients)
        {
            var sorted = Clients.Where(x => x.Rating.Equals(2))
                .OrderByDescending(x => x.PurchasesSum) 
                .ThenBy(x => x.Name)
                .ToList();           

            //bool flag;
            //do
            //{
            //    flag = true;
            //    for (int i = 0; i < sorted.Count; i++)
            //    {
            //        for (int j = 0; j < sorted.Count - 1; j++)
            //        {
            //            if (sorted[j].PurchasesSum == sorted[j + 1].PurchasesSum && String.Compare(sorted[j].Name, sorted[j + 1].Name) > 0)
            //            {
            //                var temp = sorted[j];
            //                sorted[j] = sorted[j + 1];
            //                sorted[j + 1] = temp;
            //                flag = false;
            //            }
            //        }
            //    }
            //}
            //while (flag);

            return sorted;
        }

        public static void FilterAndCountYear(List<Client> Clients, int rating)
        {
            var groupByRating = Clients.
                Where(x => x.Rating == rating).
                GroupBy(x => x.RegistrationYear());

            foreach (var group in groupByRating)
            {
                Console.WriteLine(" {0} - {1}", group.Key, group.Count());
            }
        }

        static void Main(string[] args)
        {
            //zadacha 1:
            int N = ClientsNumbers();
            
            List<Client> Customers = new List<Client>();            
            #region CreateCustomersList
            for (int i = 0; i < N; i++)
            {
                
                Console.Write("Enter customer's name: ");
                string name = Console.ReadLine();

                Console.Write("Enter customer's reistration date (DD.MM.YYYY): ");
                string regDate = Console.ReadLine();

                int purchNumber = PurchasesNumber();

                Console.Write("Enter customer's purchases sum: ");
                double sum = double.Parse(Console.ReadLine());
                               
                int rating;
                if (purchNumber >= 1 && purchNumber <= 99)
                    rating = 1;
                else if (purchNumber >= 100 && purchNumber <= 299)
                    rating = 2;
                else if (purchNumber >= 300 && purchNumber <= 499)
                    rating = 3;
                else if (purchNumber >= 500 && purchNumber <= 999)
                    rating = 4;
                else  
                    rating = 5;

                Client customer = new Client(name, regDate, purchNumber, sum, rating);

                Customers.Add(customer);                
            }
            #endregion

            //zadacha 2:
            Console.WriteLine("Zadacha 2:");
            Customers = SortByName(Customers);
            foreach (var item in Customers)
            {
                Console.WriteLine(item.PrintClient());
            }

            //zadacha 3:
            Console.WriteLine("Zadacha 3:");
            var zadacha3 = SortAndFilter(Customers);
            foreach (var item in zadacha3)
            {
                item.PrintClient();
            }
            //zadacha 4:
            Console.WriteLine("Zadacha 4:");
            int r;
            do
            {
                Console.Write("Enter rating - 1, 2, 3 ,4 or 5: ");
                r = int.Parse(Console.ReadLine());
            }
            while (r < 1 || r > 5);
            FilterAndCountYear(Customers, r);

            Console.ReadKey();
        }
    }
}
