using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    internal class Result
    {
        List<Item> packed = new List<Item>();
        int total_weight;
        int total_value;
        public Result(List<Item> list)
        {
            this.packed = list;
            foreach (Item item in packed)
            {
                this.total_weight += item.Weight;
                this.total_value += item.Price;
            }
        }
        public override string ToString()
        {
            string output = "";
            foreach (Item item in packed)
            {
                string new_string = $"{item.Index} ";
                output += new_string;
            }
            return $"Item ids: {output} \nTotal value: {total_value} \nTotal weight: {total_weight}";
        }
    }
}

