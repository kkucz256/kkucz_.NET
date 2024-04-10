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
        volatile List<int> items;
        public Row(int size, Random random)
        {
            items = new List<int>(size);

            for (int i = 0; i < size; i++)
            {
                items.Add(random.Next(1, 10));
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

        public void set_item_at_index(int index, int value)
        {
            if (index >= 0 && index < items.Count)
            {
                items[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }

        public int get_item_at_index(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                return items[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }
    }
}
