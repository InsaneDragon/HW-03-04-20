using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
namespace New_folder
{
    class Program
    {
        static int GlobalLength = 21;
        static void Main(string[] args)
        {
            int[] nums = new int[] { 24, 22, 32, 48, 13, 67, 3, 41, 31, 18, 54, 61, 22, 1, 3, 6, 27, 0, 57, 19, 24, 63, 32, 38, 45, 52, 15, 16 };
            Task[] tasks = new Task[26];
            for (int i = 0; i < 26; i++)
            {
                try
                {
                    tasks[i] = Task.Run(() => Stream(nums[i]));
                }
                catch (Exception)
                { }
                Thread.Sleep(900);
            }
            tasks[0].Wait();
            Console.ReadKey();
        }
        static void Stream(int left)
        {
            try
            {
                int limit = new Random().Next(3, 12);
                int top = 0;
                int black = top;
                int topLim = (GlobalLength - 5) / limit;
                while (true)
                {
                    if (top >= limit * topLim)
                    {
                        top = 0;
                    }
                    black = top;
                    for (int i = 0; i < black; i++)
                    {
                        Console.CursorTop = i;
                        Console.CursorLeft = left;
                        System.Console.WriteLine(" ");
                    }
                    for (int i = 0; i < limit; i++)
                    {
                        if (i == (limit - 1))
                            Console.ForegroundColor = ConsoleColor.White;
                        else if (i == (limit - 2))
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.CursorTop = top++;
                        Console.CursorLeft = left;
                        List<char> AlphabetList = new List<char>() { };
                        for (char y = 'A'; y <= 'Z'; y++)
                        {
                            AlphabetList.Add(y);
                        }
                        for (int f = 0; f <= 9; f++)
                        {
                            AlphabetList.Add(char.Parse(f.ToString()));
                        }
                        int letter = new Random().Next(0, 35);
                        System.Console.WriteLine(AlphabetList[letter]);
                    }
                    if (top == limit)
                    {
                        for (int i = top; i < GlobalLength; i++)
                        {
                            Console.CursorTop = i;
                            Console.CursorLeft = left;
                            System.Console.WriteLine(" ");
                        }
                    }
                    Thread.Sleep(8000);
                    top = black + new Random().Next(1, limit);
                }
            }
            catch (Exception)
            {

            }
        }
        static async Task<int> CalculateAsyn(int i, int c, int j)
        {
            var x = await Task.Run(() => { return i + c + j * 99 - 2; });
            //Some operations
            return x;
        }
        static int CalculateTask(int i, int c, int j)
        {
            Task<int> task = Task<int>.Factory.StartNew(() => 1);
            int u = task.Result;
            Task<int> task2 = Task<int>.Factory.StartNew(() =>
             {
                 u++;
                 return u;
             });
            return task2.Result;
        }
        static void CalculateThread()
        {
            Thread tr = new Thread(() =>
              {
                  System.Console.WriteLine("1");
                  System.Console.WriteLine("2");
                  //Some Operations
              });
              tr.Start();
        }
    }
}
