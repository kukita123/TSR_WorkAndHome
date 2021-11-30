using System;
using System.Threading;
/* 
 * Проектирайте клас, наречен Stopwatch. Работата на този клас е да симулира хронометър. 
 * Той трябва да предоставя два метода: Start и Stop. Първо извикваме метода Start, а след това метода Stop. 
 * След това питаме хронометъра за продължителността между старта и спирането. Продължителността трябва да е стойност в TimeSpan. 
 * Покажете продължителността на конзолата. Също така трябва да можем да използваме хронометърa няколко пъти (например с цикъл While). 
 * Така че трябва да можем да го стартираме да го спрем и след това да стартираме и да го спрем отново. 
 * Уверете се, че стойността на продължителността всеки път се изчислява правилно. 
 * Не бива да можем да стартираме хронометъра докато работи (защото това може да замени първоначалното начално време). 
 * Така че класът трябва да хвърли InvalidOperationException, ако е стартиран повторно, преди да е спрял.
 */

namespace StopWatch_DateTimeExercise
{
    public class Stopwatch
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private bool _isRunning;

        public void Start()
        {
            if (_isRunning)
                throw new InvalidOperationException("Stapwatch is already running!");

            _startTime = DateTime.Now;
            _isRunning = true;
        }
        public void Stop()
        {
            if (!_isRunning)
                throw new InvalidOperationException("Stopwatch isn't runnig so it can't stop");

            _endTime = DateTime.Now;
            _isRunning = false;
        }
        public TimeSpan GetDuration()
        {
            return _endTime - _startTime;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            Console.WriteLine("Enter seconds to chek the stopwatch, or enter END to stop calculation");
            Console.Write("Your choice: ");

            string input = Console.ReadLine();

            while (input!="END")
            {
                var seconds = Convert.ToInt32(input);

                stopwatch.Start();
                

                Thread.Sleep(1000 * seconds);

                stopwatch.Stop();

                Console.WriteLine("Interval duration: "+ Math.Round(stopwatch.GetDuration().TotalSeconds));

                Console.ReadKey();
                Console.WriteLine("Enter seconds to chek the stopwatch, or enter END to stop calculation");
                Console.Write("Your choice: ");
                input = Console.ReadLine();

            }

            
        }
    }
}
