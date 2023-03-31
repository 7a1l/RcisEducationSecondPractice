using System;
using prac2_2;
//  1 //
/*
class HelloWorld
{
  static void Main() 
  {
      int[] marks = new int[] {5, 4, 3, 2, 1};
      Student student1 = new Student("Fedorov", "10.05.2005", 612, marks);
      while( 0 != 1)
      {
          Console.WriteLine("1 - Edit Info\n2 - Write Info\n3 - Finish");
          int a = Convert.ToInt32(Console.ReadLine());
          switch(a)
          {
              case 1:
                  Console.Write("Введите фамилию: ");
                  String surname = Console.ReadLine();
                  Console.Write("Введите дату рождения: ");
                  String date = Console.ReadLine();
                  Console.Write("Введите номер группы: ");
                  int group = Convert.ToInt32(Console.ReadLine());
                  student1.changeProperties(surname, date, group);
                  break;
              case 2:
                  student1.info();
                  break;
              case 3:
                  return;
          }
      }
  }
}
*/


//  2//
/*class HelloWorld
{
  static void Main() 
  {
      Train[] trains = new Train[3];
      for(int i = 0; i < trains.Length; i++)
      {
          Console.Write($"Введите пункт отправления {i + 1} поезда: ");
          string d = Console.ReadLine();
          Console.Write("Введите номер поезда: ");
          int num = Convert.ToInt32(Console.ReadLine());
          Console.Write("Введите дату отправления: ");
          string day = Console.ReadLine();
          Train train = new Train(d, day, num);
          trains[i] = train;
      }
      while( 0 != 1)
      {
          Console.WriteLine("1 - Write Info\n2 - Finish");
          int a = Convert.ToInt32(Console.ReadLine());
          switch(a)
          {
              case 1:
                  Console.Write("Введите номер поезда: ");
                  int number = Convert.ToInt32(Console.ReadLine());
                  for(int i = 0; i < trains.Length; i++)
                  {
                      if(number == trains[i].TrainNumber)
                      {
                          trains[i].info();
                      }
                  }
                  break;
              case 2:
                  return;
          }
      }
  }
}*/

// 3 //
/*using System;

class HelloWorld
{
  static void Main() 
  { 
      Numbers  num = new Numbers(10, 10);
      while( 0 != 1)
      {
          Console.WriteLine("1 - Write Info\n2 - change Info\n3 - sum of numbers\n4 - is bigger num\n5 - finish");
          int a = Convert.ToInt32(Console.ReadLine());
          switch(a)
          {
              case 1:
                  num.info();
                  break;
              case 2:
                  Console.Write("введите первое число: ");
                  int num1 = int.Parse(Console.ReadLine());
                  Console.Write("введите второе число: ");
                  int num2 = int.Parse(Console.ReadLine());
                  num.changeNums(num1, num2);
                  break;
              case 3:
              Console.WriteLine("Сумма чисел: ");
                  Console.WriteLine(num.sumOfNumbers());
                  break;
              case 4:
                  Console.WriteLine("наибольшее из чисел: ");
                  Console.WriteLine(num.isBigger());
                  break;
              case 5:
                  return;
          }
      }
  }
}*/


//4 //
/*using System;

class HelloWorld 
{
  static void Main() 
  {
      
      String a = "1";
      Console.Write("Введите число: ");
      int num = int.Parse(Console.ReadLine());
      Counter number = new Counter(num);
      while(a != "0")
      {
        Console.WriteLine("1 - increment\n2 - decrement\n3 - info\n0 - exit");
        a = Console.ReadLine();
        switch(a)
        {
            case "1":
                number.increment();
                break;
            case "2":
                number.decrement();
                break;
            case "3":
                number.info();
                break;
            default:
                return;
        }
      }
  }
}*/


// 5  //


/*
class HelloWorld 
{
  static void Main() 
  {
      
      String a = "1";
      FullName fio = new FullName();
      while(a != "0")
      {
        Console.WriteLine("1 - Создать ФИО по умолчанию\n2 - Задать ФИО\n3 - info");
        a = Console.ReadLine();
        switch(a)
        {
            case "1":
                fio.info();
                break;
            case "2":
                Console.Write("Введите имя: ");
                String n = Console.ReadLine();
                Console.Write("Введите фамилию: ");
                String sn = Console.ReadLine();
                fio = new FullName(n, sn);
                fio.info();
                break;
            case "3":
                fio.info();
                break;
            default:
                return;
        }
      }
  }
}
*/
