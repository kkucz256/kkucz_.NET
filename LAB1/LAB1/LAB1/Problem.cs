using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("TestProject"), InternalsVisibleTo("Knapsack")]

namespace LAB1
{
    internal class Problem
    {
        private int n;
        private int seed;
        private List<Item> items_list = new List<Item>();

        public Problem(int n, int seed)
        {
            this.n = n;
            this.seed = seed;
            Random random = new Random(seed);
            Item.ResetIndex();
            for (int i = 0; i < n; i++)
            {
                Item new_item = new Item(random.Next(1, 10), random.Next(1, 10));
                items_list.Add(new_item);
            }
        }

        public Result solve(int count)
        {
            int total_weight = 0;
            List<Item> sorted_items = new List<Item>();
            List<Item> packed = new List<Item>();

            sorted_items = items_list.OrderByDescending(item => item.Ratio).ToList<Item>();
            for (int i = 0; i < n; i++)
            {
                if (total_weight + sorted_items[i].Weight <= count)
                {
                    packed.Add(sorted_items[i]);
                    total_weight += sorted_items[i].Weight;
                }
                else
                { break; }
            }
            return new Result(packed);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Item item in items_list)
            {
                string new_string = $"ID: {item.Index} Value: {item.Price} Weight: {item.Weight}\n";
                output += new_string;
            }
            return output;
        }

        public List<Item> Items_list
        {
            get { return items_list; }
            set { items_list = value; }
        }
    }
}

