using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    internal class Item
    {
        private int weight;
        private int price;
        private double ratio;
        static private int index;
        private int elem_index;

        public Item(int weight, int value)
        {
            this.weight = weight;
            this.price = value;
            this.ratio = (double)value / weight;
            this.elem_index = index++;
        }

        public int Weight
        {
            get { return weight; }
        }
        public int Price
        {
            get { return price; }
        }
        public int Taken { get; set; }
        public int Index
        {
            get { return elem_index; }
        }
        public double Ratio
        {
            get { return ratio; }
        }

    }
}
