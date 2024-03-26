using Newtonsoft.Json;
using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;
namespace API_Test
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            string key = "3fd321ae11994df7937388a89074c9a9";
            string call = "https://openexchangerates.org/api/latest.json?app_id=" + key;
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(call);
            JObject json = JObject.Parse(response);
            JObject rates = (JObject)json["rates"];
            bool should_continue = true;

            Console.WriteLine("All currencies: ");
            foreach (var item in rates)
            {
                Console.Write($"{item.Key} ");
            }

            while (should_continue)
            {
                Console.WriteLine("\nType one of the currencies to know it's current exchange rate from USD");
                string currency = Console.ReadLine();
                Console.WriteLine($"\n1 USD can get you {rates[currency]} {currency} ");
                Console.WriteLine("Continue? (Y/N)");
                string cont = Console.ReadLine();
                if (cont == "N")
                {
                    should_continue = false;
                    Console.WriteLine("\nThanks for using me");
                }
            }

        }


    }
}

