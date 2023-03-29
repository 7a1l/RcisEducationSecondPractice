using System;
using System.Linq;
using Garage.Models;

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
            using (gr612_fepolContext db = new gr612_fepolContext())
            {
                var car = db.Cars.ToList();
                var itinerary = db.Itineraries.ToList();
                var rightsCategory = db.RightsCategories.ToList();
                var typeCar = db.TypeCars.ToList();
                var driver = db.Drivers.ToList();
                var driverRightsCategory = db.DriverRightsCategories.ToList();
                var route = db.Routes.ToList();
                
                while (true)
                {
                    Console.Write("введите операцию(Для просмотра операций введите 9): ");
                    int op = int.Parse(Console.ReadLine()!);
                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("1 - Просмотр машин\n2 - Добавление новых машин");
                            a = int.Parse(Console.ReadLine()!);
                            switch (a)
                            {
                                case 1:
                                   
                                    foreach (var c in car)
                                    {
                                        Console.WriteLine(
                                            $"{c.id} - {c.type_car.name} {c.name} {c.state_number} {c.number_passengers}");
                                    }
                                    Console.WriteLine();
 
                                    break;
                                case 2:

                                    foreach (var tc in typeCar)
                                    {
                                        Console.WriteLine($"{tc.id} - {tc.name}");
                                    }

                                    Console.WriteLine();
                                    Console.Write("Введите ID типа машины: ");
                                    int id_type = int.Parse(Console.ReadLine()!);
                                    Console.Write("Введите Название машины: ");
                                    string name_car = Console.ReadLine()!;
                                    Console.Write("Введите Гос номер: ");
                                    string st_num = Console.ReadLine()!;
                                    Console.Write("Введите кол-во пассажиров: ");
                                    int num_pass = int.Parse(Console.ReadLine()!);
                                    Car newCar = new Car { id_type_car = id_type,name = name_car,state_number = st_num,number_passengers = num_pass };
                                    db.Cars.Add(newCar);
                                    car.Add(newCar);
                                    db.SaveChanges();
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
                                    foreach (var d in driver)
                                    {
                                        Console.WriteLine($"{d.id} - {d.first_name} {d.last_name} {d.birthdate}");
                                    }

                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.Write("Введите имя: ");
                                    string name_driver = Console.ReadLine();
                                    Console.Write("Введите фамилию: ");
                                    string surname = Console.ReadLine();
                                    Console.Write("Введите дату рождения: ");
                                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                                    Driver newDriver = new Driver { first_name = name_driver, last_name = surname, birthdate = date};
                                    db.Drivers.Add(newDriver);
                                    driver.Add(newDriver);
                                    db.SaveChanges();
                                    clearConsole();
                                    break;
                                case 3:
                                    foreach (var d in driver)
                                    {
                                        Console.WriteLine($"{d.id} - {d.first_name} {d.last_name} {d.birthdate}");
                                    }
                                    Console.Write("Введите ID водителя: ");
                                    int id_d = int.Parse(Console.ReadLine());
                                    foreach (var rc in rightsCategory)
                                    {
                                        Console.WriteLine($"{rc.id} - {rc.name}");
                                    }

                                    Console.WriteLine();
                                    Console.Write("Введите ID категории прав: ");
                                    int id_rights = int.Parse(Console.ReadLine());
                                    DriverRightsCategory newDRC = new DriverRightsCategory { id_driver = id_d, id_rights_category = id_rights};
                                    db.DriverRightsCategories.Add(newDRC);
                                    driverRightsCategory.Add(newDRC);
                                    db.SaveChanges();
                                    clearConsole();
                                    break;
                                case 4:
                                    foreach (var d in driver)
                                    {
                                        Console.WriteLine($"{d.id} - {d.first_name} {d.last_name} {d.birthdate}");
                                    }
                                    Console.Write("Введите ID водителя: ");
                                    int driv = int.Parse(Console.ReadLine());
                                    foreach (var drc in driverRightsCategory)
                                    {
                                        if(driv == drc.id_driver)
                                        Console.WriteLine(
                                            $"{drc.id_driver_navigation.first_name} {drc.id_driver_navigation.last_name} - {drc.id_rights_category_navigation.name}");
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("1 - Просмотр типов машин\n2 - Добавление типов машин");
                            a = int.Parse(Console.ReadLine()!);
                            if (a == 1)
                            {
                                foreach (var tc in typeCar)
                                {
                                    Console.WriteLine($"{tc.id} - {tc.name}");
                                }
                            }
                            else
                            {
                                Console.Write("Введите название типа машин: ");
                                TypeCar newTypeCar = new TypeCar { name = Console.ReadLine()};
                                db.TypeCars.Add(newTypeCar);
                                typeCar.Add(newTypeCar);
                                db.SaveChanges();
                                clearConsole();
                            }
                            break;
                        case 4:
                            Console.WriteLine("1 - Просмотр маршрутов\n2 - Добавление новых маршрутов");
                            a = int.Parse(Console.ReadLine()!);
                            if (a == 1)
                            { 
                                foreach (var it in itinerary)
                                {
                                    Console.WriteLine($"{it.id} - {it.name}");
                                }
                            }
                            else
                            {
                                Console.Write("Введите Маршрут: ");
                                Itinerary newIt = new Itinerary { name = Console.ReadLine()};
                                db.Itineraries.Add(newIt);
                                itinerary.Add(newIt);
                                db.SaveChanges();
                                clearConsole();
                            }
                            break;
                        case 5:
                            Console.WriteLine("1 - Просмотр рейсов\n2 - Добавление новых рейсов");
                            a = int.Parse(Console.ReadLine()!);
                            if (a == 1)
                            {
                                foreach (var r in route)
                                {
                                    Console.WriteLine(
                                        $"{r.id} - {r.id_driver_navigation.first_name} {r.id_driver_navigation.last_name} {r.id_itinerary_navigation.name} {r.number_passengers}");
                                }
                            }
                            else
                            {
                                foreach (var d in driver)
                                {
                                    Console.WriteLine($"{d.id} - {d.first_name} {d.last_name} {d.birthdate}");
                                }
                                Console.Write("Введите ID водителя: ");
                                int id_d = int.Parse(Console.ReadLine()!);
                                foreach (var c in car)
                                {
                                    Console.WriteLine(
                                        $"{c.id} - {c.type_car.name} {c.name} {c.state_number} {c.number_passengers}");
                                }
                                Console.Write("Введите ID машины: ");
                                int id_c = int.Parse(Console.ReadLine()!);
                                foreach (var it in itinerary)
                                {
                                    Console.WriteLine($"{it.id} - {it.name}");
                                }
                                Console.Write("Введите ID мартшрута: ");
                                int id_it = int.Parse(Console.ReadLine()!);
                                Console.Write("Введите Кол-во пассажиров: ");
                                int num_pass = int.Parse(Console.ReadLine()!);
                                Route newRoute = new Route { id_driver = id_d, id_car = id_c,id_itinerary = id_it, number_passengers = num_pass};
                                db.Routes.Add(newRoute);
                                route.Add(newRoute);
                                db.SaveChanges();
                                clearConsole();
                            }
                            break;
                        case 6:
                            Console.WriteLine("1 - Просмотр прав\n2 - Добавление новых прав");
                            a = int.Parse(Console.ReadLine()!);
                            if (a == 1)
                            {
                                foreach (var rc in rightsCategory)
                                {
                                    Console.WriteLine($"{rc.id} - {rc.name}");
                                }
                            }
                            else
                            {
                                Console.Write("введите новую категорию прав: ");
                                string category = Console.ReadLine();
                                RightsCategory newRc = new RightsCategory { name = category};
                                db.RightsCategories.Add(newRc);
                                rightsCategory.Add(newRc);
                                db.SaveChanges();
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
}

