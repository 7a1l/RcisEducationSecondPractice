using  System;

namespace prac2_2
{
    class Counter
    {
        private  int count = 0; 
        public Counter(int c = 0)
        {
            this.count = c;
        }
        public int increment()
        {
            return this.count++;
        }
        public int decrement()
        {
            return this.count--;
        }
        public void info()
        {
            Console.WriteLine($"\n{this.count}\n");
        }
    }
}