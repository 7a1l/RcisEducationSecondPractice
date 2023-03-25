using System;

namespace _2_3
{
    class Worker
    {
        private string name;
        private string surname;
        private int rate;
        private int days;
        public Worker(string n, string sn, int r, int d)
        {
            name = n;
            surname = sn;
            rate = r;
            days = d;
        }
        public void GetSalary()
        {
            Console.WriteLine($"{name} {surname} Заработная плата: {rate * days}р. за {days} дней");
        }
    }
}
