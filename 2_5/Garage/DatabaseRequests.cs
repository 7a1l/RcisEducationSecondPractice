using Npgsql;
using System;
namespace GarageConsoleApp
{
    public static class DatabaseRequests
    {
        public static void GetTypeCarQuery()
        {
            var querySql = "SELECT * FROM type_car";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader[0]} Название: {reader[1]}");
            }
            reader.Close();
        }
        public static void AddCarQuery(int type, string name, string stateNumber, int numberPassengers)
        {
            var querySql = $"INSERT INTO car(id_type_car, name, state_number, number_passengers) VALUES({type}, '{name}', '{stateNumber}', {numberPassengers})";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd.ExecuteNonQuery();
        }
        public static void AddItineraryQuery(string n)
        {
            var querySql = $"INSERT INTO itinerary(name) VALUES ('{n}')";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd.ExecuteNonQuery();
        }
        public static void GetItineraryQuery()
        {
            var querySql = "SELECT * FROM itinerary";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader[0]} Название: {reader[1]}");
            }
            reader.Close();
        }
        public static void AddRouteQuery(int iddriver, int idcar, int iditinerary, int numberpassengers)
        {
            var querySql = $"INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) VALUES ({iddriver}, {idcar}, {iditinerary}, {numberpassengers});";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd.ExecuteNonQuery();
        }
        public static void GetRouteQuery()
        {
           var querySql = "SELECT route.id, dr.first_name, cr.name, it.name, route.number_passengers " + 
                          "FROM route " + 
                          "INNER JOIN driver dr on route.id_driver = dr.id " + 
                          "INNER JOIN car cr on cr.id = route.id_car " + 
                          "INNER JOIN itinerary it on route.id_itinerary = it.id ";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader[0]} имя водителя: {reader[1]} название машины: {reader[2]} маршрут: {reader[3]} кол-во пассажиров: {reader[4]}");
            }
            reader.Close();
        }
        public static void GetCarQuery()
        {
            var querySql = "SELECT * FROM car";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader[0]} ID типа машины: {reader[1]} Название: {reader[2]} Гос Номер: {reader[3]} Кол-во пассажиров: {reader[4]}");
            }
            reader.Close();
        }
        public static void AddTypeCarQuery(string n)
        {
            var querySql = $"INSERT INTO type_car(name) VALUES ('{n}')";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd.ExecuteNonQuery();
        }
        public static void AddDriverQuery(string firstName, string lastName, DateTime birthdate)
        {
            var querySql = $"INSERT INTO driver(first_name, last_name, birthdate) VALUES ('{firstName}', '{lastName}', '{birthdate}')";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd.ExecuteNonQuery();
        }
        public static void GetDriverQuery()
        {
            var querySql = "SELECT * FROM driver";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader[0]} Имя: {reader[1]} Фамилия: {reader[2]} Дата рождения: {reader[3]}");
            }
            reader.Close();
        }
        public static void AddRightsCategoryQuery(string nam)
        {
            var querySql = $"INSERT INTO rights_category(name) VALUES ('{nam}')";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd.ExecuteNonQuery();
        }

        public static void GetRightsCategoryQuery()
        {
            var querySql = "select * from rights_category";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader[0]} Категория прав: {reader[1]}");
            }
            reader.Close();
        }
        public static void AddDriverRightsCategoryQuery(int driver, int rightsCategory)
        {
            var querySql = $"INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES ({driver}, {rightsCategory})";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            cmd.ExecuteNonQuery();
        }
        public static void GetDriverRightsCategoryQuery(int drive)
        {
            var querySql = "SELECT dr.first_name, dr.last_name, rc.name " +
                           "FROM driver_rights_category " +
                           "INNER JOIN driver dr on driver_rights_category.id_driver = dr.id " +
                           "INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category " +
                           $"WHERE dr.id = {drive}";
            var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Имя: {reader[0]} Фамилия: {reader[1]} Категория прав: {reader[2]}");
            }
            reader.Close();
        }
    }
}
