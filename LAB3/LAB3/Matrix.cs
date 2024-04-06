using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    internal class Matrix
    {
        List<Row> matrix;
        int size;

        public Matrix(int size)
        {
            this.matrix = new List<Row>();
            this.size = size;
            for (int i = 0; i < size; i++) 
            {
                Row row = new Row(size);
                matrix.Add(row);
            }
           

            
        }
        /*
        public List<int> multiply(Matrix matrix_no2)
        {
            List<int> result = new List<int>(size);

            for(int i=0; i < size; i++)
            {
                List<int> current_row = matrix[i];
                foreach(int item in current_row)
                {
                    item * matrix_no2
                }
               
            }


        }*/


        public override string ToString()
        {
            string items = "";
            foreach (Row row in matrix)
            {
                items += $"| {row}|\n";
            }
            return items;
        }

    }
}
