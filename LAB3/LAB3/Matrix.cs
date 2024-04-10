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
        volatile List<Row> matrix;
        int size;
        int seed;

        public Matrix(int size, int seed)
        {
            this.matrix = new List<Row>();
            this.size = size;
            this.seed = seed;

            Random random = new Random(seed);

            for (int i = 0; i < size; i++)
            {
                Row row = new Row(size, random);
                matrix.Add(row);
            }
        }

        public void calculate_row(Matrix other, int rowIndex, List<Row> output)
        {
            if (size != other.size)
            {
                throw new ArgumentException("Matrices must have the same size for multiplication");
            }
            if (rowIndex < 0 || rowIndex >= size)
            {
                throw new ArgumentOutOfRangeException("Invalid row index");
            }

            Row resultRow = new Row(size, new Random(seed));

            for (int i = 0; i < size; i++)
            {

                int sum = 0;
                for (int j = 0; j < size; j++)
                {

                    sum += this.matrix[rowIndex].get_item_at_index(j) * other.matrix[j].get_item_at_index(i);
                }
                resultRow.set_item_at_index(i, sum);
            }

            lock (output)
            {
                output.Add(resultRow);
            }
        }



        public override string ToString()
        {
            string items = "";
            foreach (Row row in matrix)
            {
                items += $"| {row}|\n";
            }
            return items;
        }
        public void set_values(List<Row> rows)
        {
            if (rows.Count != size)
            {
                throw new ArgumentException("Invalid number of rows");
            }

            matrix = rows;
        }

    }
}
