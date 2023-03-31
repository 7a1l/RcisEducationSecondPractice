using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _2_6
{
    class Program
    {
        
        static async Task Main()
        {
            if (!File.Exists("logs.txt"))
            {
                File.Create("logs.txt");
                return;
            }
            
            List<log> logs = new List<log>();
            List<string> info = new List<string>();
            using (StreamReader reader = new StreamReader("logs.txt"))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    info.Add(line);
                }
            }

           
            for (int i = 0; i < info.Count - 1; i+= 6)
            {
                logs.Add(new log(info[i], info[i + 1 ], info[i + 2], info[i+ 3], info[i + 4], info[i + 5]));
            }

            while (true)
            {
                Console.WriteLine("1 - узнать информацию об ингредиенте\n2 - просмотреть историю запросов\n3 - удалить историю запросов");
            int a = int.Parse(Console.ReadLine()!);
            switch (a)
            {
                case 1 :
                    Console.Write("Введите ингредиент:  "); 
                    string ingr = Console.ReadLine(); 
                    string url = $"https://api.edamam.com/api/food-database/v2/parser?app_id=17414e9b&app_key=2d6bf29e1d8df1f20427f8deb06c7663&ingr={ingr}&nutrition-type=cooking";
                    Information ingred = JsonConvert.DeserializeObject<Information>(GetContent(url));
                    if (ingred.parsed != null)
                    {
                        for (int i = 0; i < ingred.parsed.Length; i++)
                        {
                            Console.WriteLine(
                                $"{ingred.parsed[i].food.KnownAs} {ingred.parsed[i].food.category}\nЭнегретическая ценность Ккал на 100г: {ingred.parsed[i].food.nutrients.ENERC_KCAL}\nпротеин: {ingred.parsed[i].food.nutrients.PROCNT}\nпротеин: {ingred.parsed[i].food.nutrients.FAT}\nУглеводы: {ingred.parsed[i].food.nutrients.FIBTG}\n");
                        }
                        using (StreamWriter file = new StreamWriter("logs.txt", true))
                        {
                    
                            for (int i = 0; i < ingred.parsed.Length; i++)
                            {
                                await file.WriteAsync($"{DateTime.Now}:\n{ingred.parsed[i].food.KnownAs}:\n{ingred.parsed[i].food.nutrients.ENERC_KCAL}\n{ingred.parsed[i].food.nutrients.PROCNT}\n{ingred.parsed[i].food.nutrients.FAT}\n{ingred.parsed[i].food.nutrients.FIBTG}\n");
                            }
                    
                        }
                    }

                    break;
                case 2:
                    foreach (var log in logs)
                    {
                        Console.WriteLine($"{log.Date}\n{log.KnownAs}\nЭнегретическая ценность Ккал на 100г: {log.ENERC_KCAL}\nпротеин: {log.PROCNT}\nпротеин: {log.FAT}\nУглеводы: {log.FIBTG}\n");
                    }
                    break;
                case 3:
                    File.Delete("logs.txt");
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
