using System;

namespace prac2_2
{

    class Student
    {
        private string surname;
        private DateTime birthday;
        private int groupNumber;
        private int[] marks;

        public Student(string s, string bd, int group, int[] m)
        {
            this.surname = s;
            this.birthday = Convert.ToDateTime(bd);
            this.groupNumber = group;
            this.marks = m;
        }

        public void changeProperties(string s, string bd, int group)
        {
            this.surname = s;
            this.birthday = Convert.ToDateTime(bd);
            this.groupNumber = group;
            info();
        }

        public void info()
        {
            Console.WriteLine(
                $"surname - {this.surname}\nbirthday - {this.birthday}\ngroup number - {this.groupNumber}");
            Console.WriteLine("Оценки: ");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"{marks[i]} ");
            }

            Console.WriteLine();
        }
    }
}