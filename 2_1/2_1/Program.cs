using System;
using System.Linq;
using System.Collections.Generic;
namespace _2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("выберите номер задания: ");
            int task = int.Parse(Console.ReadLine()!);
            switch(task)
            {
                case 1:
                    TaskOne();
                    break;
                case 2:
                    TaskTwo();
                    break;
                case 3:
                    TaskThree();
                    break;
            }
        }
        static void TaskOne()
        {
            Console.Write("Введите 'Камни': ");
            string S = Console.ReadLine();
            Console.Write("Введите 'Драгоценности': ");
            string J = Console.ReadLine();
            var countOfDrag = J.Where(x => S.Contains(x)).Count();
            Console.Write(countOfDrag);
        }
        static void TaskTwo()
        {
            int n = new Random().Next(2, 10);
            int[] candidates = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите Число в массив: ");
                candidates[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Введите таргет: ");

            int target = int.Parse(Console.ReadLine()!);
            Array.Sort(candidates);
            List<List<int>> result = CombinationSumHelper(candidates, target, 0);
            Console.WriteLine(string.Join("\n", result.Select(x => $"[{string.Join(",", x)}]")));
        }
        static void TaskThree()
        {
            int n = new Random().Next(2, 10);
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите Число в массив: ");
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(SameElements(array, n));
        }

        static bool SameElements(int[] array, int n)
        {
            Array.Sort(array);
            for (int i = 0; i < n - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    return true;
                }
            }
            return false;
        }


        static List<List<int>> CombinationSumHelper(int[] candidates, int target, int start)
        {
            List<List<int>> result = new();
            if (target == 0)
            {
                result.Add(new List<int>());
                return result;
            }
            for (int i = start; i < candidates.Length && candidates[i] <= target; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1])
                {
                    continue;
                }
                foreach (var combination in CombinationSumHelper(candidates, target - candidates[i], i + 1))
                {
                    combination.Insert(0, candidates[i]);
                    result.Add(combination);
                }
            }
            return result;
        }
    }
}
