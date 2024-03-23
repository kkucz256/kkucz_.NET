using System.Runtime.InteropServices;
using System.Text.Json;

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
            Weather_API weather = new Weather_API(city, API_key);
            response = await weather.get_data();

            Data data = JsonSerializer.Deserialize<Data>(response);
            Console.WriteLine(data);

        }
    }


}


