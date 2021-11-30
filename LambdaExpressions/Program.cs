
using System;

namespace LambdaExpressions
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var books = new BookRepository().GetBooks(); //books is a ist of Book, so we can use methods of class List, for example FindAll() -it requires a predicate as an argument

        //    var cheapBooks = books.FindAll(IsCheaperThan10); //cheapBooks is a list of Book
        //    foreach (var item in cheapBooks)
        //    {
        //        Console.WriteLine(item.Title + " " + item.Price);
        //    }


        //    Console.ReadKey();
        //}

        //static bool IsCheaperThan10(Book book) // !!! it's a predicate - a method, that returns true or false, dependig in condition inside
        //{
        //    return book.Price < 10;
        //}


        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks(); //books is a ist of Book, so we can use methods of class List, for example FindAll() -it requires a predicate as an argument

            var cheapBooks = books.FindAll(b => b.Price < 10);
       

            foreach (var item in cheapBooks)
            {
                Console.WriteLine(item.Title + " " + item.Price);
            }
            
            Console.ReadKey();
        }
    }
}
