using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    internal class Data
    {
        public int Id { get; set; }
        public Weather[]? weather { get; set; }
        public Main? main { get; set; }
        public required string name { get; set; }

        public override string ToString()
        {
            return $"Current weather in {name} is {weather[0].description}\nTemp: {main.temp}°C, feels like: {main.feels_like}°C, pressure: {main.pressure}hPa";
        }
    }
}

