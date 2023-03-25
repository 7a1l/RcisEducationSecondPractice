using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace _2_6
{
    class Program
    {
        static void GetTime(WeatherForecast forecast)
        {
            for (int i = 0; i < 39; i++)
            {
                DateTime dateOne = Convert.ToDateTime(forecast.list[i].dt_txt);
                DateTime dateTwo = Convert.ToDateTime(forecast.list[i + 1].dt_txt);
                if (i == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(dateOne.ToString("MM/dd/yyyy"));
                }
                if (dateOne.Day == dateTwo.Day)
                {
                    Console.WriteLine($"{dateOne.ToString("T")} Погода - {forecast.list[i].weather[0].description} {forecast.list[i].main.temp}°C Ощущается как: {forecast.list[i].main.feels_like}°C Скорость ветра - {forecast.list[i].wind.speed} м/с");
                }
                else
                {
                    Console.WriteLine($"{dateOne.ToString("T")} Погода - {forecast.list[i].weather[0].description} {forecast.list[i].main.temp}°C Ощущается как: {forecast.list[i].main.feels_like}°C Скорость ветра - {forecast.list[i].wind.speed} м/с");
                    Console.WriteLine();
                    Console.WriteLine(dateTwo.ToString("MM/dd/yyyy"));
                }


            }
        }
        static WeatherForecast GetForecast(string request)
        {
            return JsonConvert.DeserializeObject<WeatherForecast>(request);
        }
        static WeatherData GetWeathertoday(string request)
        {
            return JsonConvert.DeserializeObject<WeatherData>(request);
        }
        static void Main()
        {
            string url;
            string town;
            string text = "Прогноз погоды\n1 - Прогноз погоды на 5 дней\n2 - прогноз погоды сейчас\n";
            Console.SetCursorPosition(50, 0);
            Console.Write(text);
            while (true)
            {
                Console.Write("\nВведите операцию  (для завершения работы введите любой символ): ");
                string operation = Console.ReadLine();
                switch (operation)
                {
                    case "1":
                        Console.Write("Введите город:  ");
                        town = Console.ReadLine();
                        url = $"https://api.openweathermap.org/data/2.5/forecast?q={town}&lang=ru&appid=918b97276d8773fbec99bd15e99e067d&units=metric";
                        WeatherForecast forecast = GetForecast(GetContent(url));
                        GetTime(forecast);
                        break;
                    case "2":
                        Console.WriteLine("Введите город: ");
                        town = Console.ReadLine();
                        url = $"https://api.openweathermap.org/data/2.5/weather?q={town}&lang=ru&appid=918b97276d8773fbec99bd15e99e067d&units=metric";
                        WeatherData weatherToday = GetWeathertoday(GetContent(url));
                        Console.WriteLine($"\nПрогноз погоды для {weatherToday.name} '{weatherToday.sys.country}':\nПогода - {weatherToday.weather[0].main} {weatherToday.weather[0].description}\nТемпература: {weatherToday.main.temp}°C Ощущается как: {weatherToday.main.feels_like}°C\nСкорость ветра - {weatherToday.wind.speed} м/с");
                        break;
                    default:
                        return;
                }
            }
        }
        static string GetContent(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream()!);
            StringBuilder output = new StringBuilder();
            output.Append(reader.ReadToEnd());
            response.Close();
            return output.ToString();
        }
    }
}
