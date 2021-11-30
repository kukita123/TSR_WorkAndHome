using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionarySoftUni
{
    class Program
    {
        static void Odds(string input)
        {
            string[] words = input.Split(' ');

            var couples = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (couples.ContainsKey(word))
                    couples[word]++; //it icreases the dictionary's value
                else
                    couples[word] = 1;
            }

            List<string> result = new List<string>();

            foreach (var pair in couples)
            {
                if (pair.Value % 2 != 0)
                    result.Add(pair.Key);
            }
            Console.WriteLine(String.Join(" ", result));
        }

        static void Phones()
        {
            var phones = new Dictionary<string, string>();
            string inputData = Console.ReadLine();

            while (inputData != "END")
            {
                string[] words = inputData.Split(' ');

                if (words.Length > 3)
                //throw new InvalidOperationException();
                {
                    Console.WriteLine("Incorrect input");
                    break;
                }
                if (words[0] == "A")
                    phones[words[1]] = words[2];
                    //phones.Add(words[1], words[2]);
                else if (words[0] == "S")
                {
                    if (phones.ContainsKey(words[1]))
                        Console.WriteLine(words[1] + " -> " + phones[words[1]]);
                    else
                        Console.WriteLine("Contact {0} does not exist.", words[1]);
                }
                else
                    Console.WriteLine("Wrong command");

                inputData = Console.ReadLine();
            }
        }

        //Речник с индекси темите и съдържание списък от ученици до 5 броя ученици във всеки:

        static void DistributeThemes(List<string>students, List<string> themes)
        {
            //Речник с индекси темите и съдържание списък от ученици до 5 броя ученици във всеки:
            var distributed = new Dictionary<string, List<string>>();            

            for (int i = 0; i < themes.Count; i++)
            {
                distributed.Add(themes[i], new List<string>());
            }

            Random random = new Random();
            int rear = 0;   //маркер, с който ще се обхожда речника от елемента с индекс 0 до последния и ще 
                            //нулира след приключване на всички теми

            while (students.Count > 0)
            {
                //избор на случаен ученик от списъка с ученици - чрез случаен номер в списъка
                int index = random.Next(0, students.Count); //
                string student = students[index];
                                
                if (rear < themes.Count)
                {
                    distributed[themes[rear]].Add(student);
                    students.RemoveAt(index);
                    rear++;
                }
                else
                    rear = 0;                
            }

            string path = @"C:\FilesDemo\8aDistributedThemes.txt";
            foreach (var item in distributed)
            {
                item.Value.Sort();
                Console.WriteLine(item.Key);
                Console.WriteLine(String.Join(", ",item.Value));
                Console.WriteLine();
                string line ="\n" + item.Key+ "\n" + String.Join(", ", item.Value)+"\n";
                File.AppendAllText(path,line);
            }
        }  

        static void Main(string[] args)
        {
            List<string> themes = new List<string>()
            {
                "1. Олимпийските медалисти на Пловдив",
                "2. Световно известни артисти на Пловдив",
                "3. Дигиталните технологии и човешкото здраве ",
                "4. Дигиталните технологии и околната среда",
                "5. Вредите и ползите от използване на мобилен телефон",
                "6. Математика в природата"
            };

            List<string> students = new List<string>();
            string path = @"C:\FilesDemo\8a.txt";
            students = File.ReadAllLines(path).ToList();

            DistributeThemes(students, themes);

            //string input = Console.ReadLine().ToLower();

            //Odds(input);       

           // Phones();


            Console.ReadKey();
        }
    }
}
/*
A Nakov +359888001122
A RoYaL(Ivan) 666
A Gero 5559393
A Simo 02/987665544
S simo
S RoYaL
S RoYaL(Ivan)
END

 */
