using System;

namespace _2_4
{
    class Program
    {
        static int ToDecimal(string roman)
        {
            char[] romanChars = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] decimalNums = { 1, 5, 10, 50, 100, 500, 1000 };
            int res = 0;
            int prev = 0;
            int len = roman.Length;
            for (int i = len - 1; i >= 0; i--)
            {
                char current = roman[i];
                int value = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (romanChars[j] == current)
                    {
                        value = decimalNums[j];
                        break;
                    }
                }
                res = value < prev ? res -= value : res += value;
                prev = value;
            }
            return res;
        }
        static void Main()
        {
            Console.Write("Введите римское число: ");
            string roman = Console.ReadLine();
            Console.WriteLine(ToDecimal(roman));
        }
    }
}
