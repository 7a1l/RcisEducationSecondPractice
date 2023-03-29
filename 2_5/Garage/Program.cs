using System;

namespace GarageConsoleApp
{
    public class Program
    {
        public static void clearConsole()
        {
            string text =
                "1 - Работа с Машинами\n2 - Работа с водителями\n3 - Работа с типом машин\n4 - работа с маршрутами\n5 - работа с рейсами\n6 - работа с правами";
            Console.Clear();
            Console.WriteLine(text);
        }
        public static void Main()
        {
            int a;
            clearConsole();
            while(true)
            {
                Console.Write("введите операцию(Для просмотра операций введите 9): ");
                int op = int.Parse(Console.ReadLine());
                switch(op)
                {
                    case 1:
                        Console.WriteLine("1 - Просмотр машин\n2 - Добавление новых машин");
                        a = int.Parse(Console.ReadLine()!);
                       switch(a)
                       {
                           case 1:
                               DatabaseRequests.GetCarQuery();
                            break;
                           case 2:
                               DatabaseRequests.GetTypeCarQuery();
                               Console.Write("Введите ID типа машины: ");
                               int id_type = int.Parse(Console.ReadLine()!);
                               Console.Write("Введите Название машины: ");
                               string name_car = Console.ReadLine()!;
                               Console.Write("Введите Гос номер: ");
                               string st_num = Console.ReadLine()!;
                               Console.Write("Введите кол-во пассажиров: ");
                               int num_pass= int.Parse(Console.ReadLine()!);
                               DatabaseRequests.AddCarQuery( id_type,name_car, st_num, num_pass);
                               clearConsole();
                               break;
                       }
                        break;
                    case 2:
                        Console.WriteLine("1 - Просмотр Водителей\n2 - Добавление новых водителей\n3 - добавление категорий прав водителю\n4 - Просмотр прав водителя");
                        a = int.Parse(Console.ReadLine()!);
                        switch(a)
                        {
                            case 1:
                                DatabaseRequests.GetDriverQuery();
                                break;
                            case 2:
                                Console.Write("Введите имя: ");
                                string name_driver = Console.ReadLine();
                                Console.Write("Введите фамилию: ");
                                string surname = Console.ReadLine();
                                Console.Write("Введите дату рождения: ");
                                DateTime date = Convert.ToDateTime(Console.ReadLine());
                                DatabaseRequests.AddDriverQuery(name_driver, surname, date);
                                clearConsole();
                                break;
                            case 3:
                                DatabaseRequests.GetDriverQuery();
                                Console.Write("Введите ID водителя: ");
                                int id_d = int.Parse(Console.ReadLine());
                                DatabaseRequests.GetRightsCategoryQuery();
                                Console.Write("Введите ID категории прав: ");
                                int id_rights = int.Parse(Console.ReadLine());
                                DatabaseRequests.AddDriverRightsCategoryQuery(id_d, id_rights);
                                clearConsole();
                                break;
                            case 4:
                                DatabaseRequests.GetDriverQuery();
                                Console.Write("Введите ID водителя: ");
                                int driver = int.Parse(Console.ReadLine());
                                DatabaseRequests.GetDriverRightsCategoryQuery(driver);
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("1 - Просмотр типов машин\n2 - Добавление типов машин");
                        a = int.Parse(Console.ReadLine()!);
                        if (a == 1)
                        {
                            DatabaseRequests.GetTypeCarQuery();
                        }
                        else
                        {
                            Console.Write("Введите название типа машин: ");
                            DatabaseRequests.AddTypeCarQuery(Console.ReadLine());
                            clearConsole();
                        }
                        break;
                    case 4:
                        Console.WriteLine("1 - Просмотр маршрутов\n2 - Добавление новых маршрутов");
                        a = int.Parse(Console.ReadLine()!);
                        if (a == 1)
                        { 
                            DatabaseRequests.GetItineraryQuery();
                        }
                        else
                        {
                            Console.Write("Введите Маршрут: ");
                            DatabaseRequests.AddItineraryQuery(Console.ReadLine());
                            clearConsole();
                        }
                        break;
                    case 5:
                        Console.WriteLine("1 - Просмотр рейсов\n2 - Добавление новых рейсов");
                        a = int.Parse(Console.ReadLine()!);
                        if (a == 1)
                        {
                            DatabaseRequests.GetRouteQuery();
                        }
                        else
                        {
                            DatabaseRequests.GetDriverQuery();
                            Console.Write("Введите ID водителя: ");
                            int id_d = int.Parse(Console.ReadLine()!);
                            DatabaseRequests.GetCarQuery();
                            Console.Write("Введите ID машины: ");
                            int id_c = int.Parse(Console.ReadLine()!);
                            DatabaseRequests.GetItineraryQuery();
                            Console.Write("Введите ID мартшрута: ");
                            int id_it = int.Parse(Console.ReadLine()!);
                            Console.Write("Введите Кол-во пассажиров: ");
                            int num_pass = int.Parse(Console.ReadLine()!);
                           DatabaseRequests.AddRouteQuery(id_d,id_c, id_it,num_pass); 
                           clearConsole();
                        }
                        break;
                    case 6:
                        Console.WriteLine("1 - Просмотр прав\n2 - Добавление новых прав");
                        a = int.Parse(Console.ReadLine()!);
                        if (a == 1)
                        {
                            DatabaseRequests.GetRightsCategoryQuery();
                        }
                        else
                        {
                            Console.Write("введите новую категорию прав: ");
                            string category = Console.ReadLine();
                            DatabaseRequests.AddRightsCategoryQuery(category);
                            clearConsole();
                        }
                        break;
                    case 9:
                        clearConsole();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}

