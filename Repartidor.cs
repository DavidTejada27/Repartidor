
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Repartidor
{
    public static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ReadAllText(args[0], args[1], args[2]);
            }
            catch
            {
                Console.WriteLine("\n\n*****************************************************\n\n Please, verify your arguments.\nExample: Repartidor.exe Students.txt Topics.txt numGroups");
            }
            
        }

        public static void ReadAllText(string path, string path2, string num)
        {
            List<string> Students = File.ReadLines(path).ToList();
            Students.Shuffle();
            List<string> Topics = File.ReadLines(path2).ToList();
            Topics.Shuffle();
            int Groups = Convert.ToInt32(num);
            int studentsxGroups = Students.Count / Groups;
            int studentsLeft = Students.Count % Groups;
            int topicsxGroups = Topics.Count / Groups;
            int topicsLeft = Topics.Count % Groups;
            int x = 0;
            if(Students.Count != 0 && Students.Count >= Groups && Topics.Count >= Groups)
            {
                for (int i = 0; i < Groups; i++)
                {
                    if(studentsLeft > 0 && topicsLeft > 0)
                    {
                        Console.WriteLine("\nGroups #{0}(Students {1}, Topics {2})\n         Estudiantes:\n", i+1, studentsxGroups + 1, topicsxGroups + 1);
                        Console.WriteLine("         {0}", Students[0]);
                        Students.RemoveAt(0);
                        studentsLeft--;
                    
                        for(int j = 0; j < studentsxGroups; j++)
                        {
                            Console.WriteLine("         {0}", Students[0]);
                            Students.RemoveAt(0);
                        }
                    }
                    else 
                    {
                        Console.WriteLine("\nGroups #{0}(Students {1}, Topics {2})\n         Estudiantes:\n", i+1, studentsxGroups, topicsxGroups);
                        for(int j = 0; j < studentsxGroups; j++)
                        {
                            Console.WriteLine("         {0}", Students[0]);
                            Students.RemoveAt(0);
                        }

                    }
                    if(topicsLeft > 0)
                    {
                        Console.WriteLine("\n         Topics:\n");
                        Console.WriteLine("             {0}", Topics[0]);
                        Topics.RemoveAt(0);
                        topicsLeft--;
                        for(x = 0; x < topicsxGroups; x++)
                        {
                            Console.WriteLine("         {0}", Topics[0]);
                            Topics.RemoveAt(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n         Topics:\n");

                        for(x = 0; x < topicsxGroups; x++)
                        {
                            Console.WriteLine("         {0}", Topics[0]);
                            Topics.RemoveAt(0);
                        } 
                    }    
                }
            }
            else 
            {
                Console.WriteLine("\n\n*****************************************************\n\n You Had an error, please verify your files .txt have more students and topics than groups");
            }

        }

        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while(n > 1)
            {
                n--;
                int k = rng.Next(n+1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
