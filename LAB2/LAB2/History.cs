using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    internal class History : DbContext
    {
        public DbSet<Database_data> Measurements { get; set; }
        public History()
        {
           Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=database.db");
        }
        
        public List<Database_data> sort_data_desc(string sort_by)
        {
            var data = Measurements.ToList();

            switch (sort_by.ToLower())
            {
                case "temp":
                    data = data.OrderByDescending(d => d.Temp).ToList();
                    break;
                case "pressure":
                    data = data.OrderByDescending(d => d.Pressure).ToList();
                    break;
                case "id":
                    data = data.OrderByDescending(d => d.Id).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid sorting option");
                    break;
            }
            return data;
        }

        public List<Database_data> sort_data_asc(string sort_by)
        {
            var data = Measurements.ToList();

            switch (sort_by.ToLower())
            {
                case "temp":
                    data = data.OrderBy(d => d.Temp).ToList();
                    break;
                case "pressure":
                    data = data.OrderBy(d => d.Pressure).ToList();
                    break;
                case "id":
                    data = data.OrderBy(d=>d.Id).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid sorting option");
                    break;
            }

            return data;
        }
    }
}
