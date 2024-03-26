using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
[assembly: InternalsVisibleTo("Weather_GUI")]

namespace LAB2
{
    internal class Database_data
    {
        public int Id { get; set; }
        public float? Temp { get; set;}
        public float? Feels_like { get; set;}
        public int? Pressure { get; set;}

        public required string Name { get; set; }

        public required string Time { get; set; }

        public override string ToString()
        {
            return $"{Time}  City: {Name}  Temp: {Temp}°C  Feels like: {Feels_like}°C  Pressure: {Pressure}hPa";
        }
    }
}
