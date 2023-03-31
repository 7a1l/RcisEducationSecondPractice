using System;

namespace prac2_2
{
    class FullName
    {
        private String name; 
        private String surname;
        public FullName()
        {
            this.name = "Pavel";
            this.surname = "Fedorov";
        }
        public FullName(String n, String sn)
        {
            this.name = n;
            this.surname = sn;
        }
        public void info()
        {
            Console.WriteLine($"{this.name} {this.surname}");
        }
        ~FullName()
        {
            Console.WriteLine($"Объект {this.name}, {this.surname} удален");
        }
    }
}