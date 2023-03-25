using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3
{
    class WorkerTwo
    {
        private string name;
        private string surname;
        private int rate;
        private int days;
        public WorkerTwo(string n, string sn, int r, int d)
        {
            name = n;
            surname = sn;
            rate = r;
            days = d;
        }
        public void GetSalary()
        {
            Console.WriteLine($"{this.name} {this.surname} - {this.rate * days} p.");
        }
        public string Name
        {
            get { return name; }
        }
        public string Surname
        {
            get { return surname; }
        }
        public int Rate
        {
            get { return rate; }
        }
        public int Days
        {
            get { return days; }
        }
    }
}
