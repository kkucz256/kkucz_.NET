using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            for (int i = 0; i < n; i++) 
            {
                Item new_item = new Item(random.Next(1,11), random.Next(1,11));
                items_list.Add(new_item);
                Console.WriteLine("ID: " + items_list[i].Index.ToString() +" Value: " + items_list[i].Price.ToString()+ " Weight: "+ items_list[i].Weight.ToString());
            }
        }

        public Result solve(int count) 
        {
            int total_weight = 0;
            List<Item> sorted_items = new List<Item>();
            List<Item> packed = new List<Item>();


            sorted_items = items_list.OrderByDescending(item => item.Ratio).ToList<Item>();
            for(int i = 0; i < n;i++) 
            {
                 if (total_weight + sorted_items[i].Weight <= count)
                 {
                    packed.Add(sorted_items[i]);
                    total_weight += sorted_items[i].Weight;
                 }
                 else
                 {
                     break;
                 }
            }


            return new Result(packed);
           }

        }
     


    
}
