using System;

namespace prac2_2
{
    class Train
    {
        private string destination;
        private DateTime date;
        public int TrainNumber;
        
        public Train(string d, string day, int num)
        {
            this.destination = d;
            this.date = Convert.ToDateTime(day);
            this.TrainNumber = num;
        }
        public void info()
        {
            Console.WriteLine($"пункт назначения - {this.destination}\nвремя отправления - {this.date}\nномер поезда - {this.TrainNumber}");
            Console.WriteLine();
        }
    }
}