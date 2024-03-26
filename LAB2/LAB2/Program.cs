using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace LAB2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string API_key = "23cdcedd6e46956ea046361eac860a65";
            string city = "";
            string response = "";

            Console.WriteLine("\nType a city that you would like to check weather in: ");
            city = Console.ReadLine().ToLower();

            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");


            Weather_API weather = new Weather_API(city, API_key);
            response = await weather.get_data();
            Data data = JsonSerializer.Deserialize<Data>(response);

            Database_data temp = new Database_data()
            {
                Name = data.name,
                Pressure = data.main.pressure,
                Temp = data.main.temp,
                Feels_like = data.main.feels_like,
                Time = formattedTime

            };

            using (History history = new History())
            {
                history.Measurements.Add(temp);
                await history.SaveChangesAsync();

            }

        }
    }


}


