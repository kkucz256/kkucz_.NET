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
        private static int index = 0;
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
            set { weight = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Taken { get; set; }
        public int Index
        {
            get { return elem_index; }
            set { elem_index = value; }
        }
        public double Ratio
        {
            get { return ratio; }
        }

        public static void ResetIndex()
        {
            index = 0;
        }

    }
}
