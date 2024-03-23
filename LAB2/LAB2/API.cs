using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    internal class Weather_API
    {
        private string city;
        private string api_key;
        public HttpClient client;
        public Weather_API(string city, string api_key)
        {
            this.city = city;
            this.api_key = api_key;
        }
        public async Task<string> get_data()
        {
            client = new HttpClient();
            string weather = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={api_key}";
            string response = await client.GetStringAsync(weather);
            return response;
        }
    }
}
