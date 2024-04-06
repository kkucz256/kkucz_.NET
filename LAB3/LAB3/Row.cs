using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    internal class Row
    {
        List<int> items;
        public Row(int size) 
        {
            Random random = new Random();
            items = new List<int>(size);

            for(int i = 0; i < size; i++)
            {
                items.Add(random.Next(10,20));
            }

        }

        public override string ToString()
        {
            string row = "";
            foreach (int i in items)
            {
                row += i.ToString() + " ";
            }
            return row;
        }
    }
}
