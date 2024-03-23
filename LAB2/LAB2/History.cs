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
        public DbSet<Data> Data_history { get; set; }
        public History()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=database.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data>().HasData(

                new Data(){ Id = 1, name = "Wrocław"/*,main = new Main { Id = 1, temp = 3, feels_like = 5 }*/ },
                new Data(){ Id = 2, name = "Warsaw"/*, main = new Main { Id = 2, temp = 5, feels_like = 8 }*/ },
                new Data(){ Id = 3, name = "Krakow"/*, main = new Main { Id = 3, temp = 3, feels_like = 5 }*/ },
                new Data() { Id = 4, name = "Żary"/*, main = new Main { Id = 3, temp = 3, feels_like = 5 }*/ }
                );

        }
    }
}
