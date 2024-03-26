using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
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
        public Main? main { get; set; }
        public required string name { get; set; }
     
    }
}

