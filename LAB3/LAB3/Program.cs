namespace LAB3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 500;
            int seed_1 = 1;
            int seed_2 = 2;
            int cores_no = 10;

            Matrix a = new Matrix(size, seed_1);
            Matrix b = new Matrix(size, seed_2);

            //Console.WriteLine(a);
            //Console.WriteLine(b);
  
            for (int threads_no=1; threads_no<=cores_no; threads_no++)
            {
                List<Row> output = new List<Row>(size);
                int rows_perT = size / threads_no;
                var watch = System.Diagnostics.Stopwatch.StartNew();
                thread(threads_no, rows_perT, output);
                watch.Stop();
                Console.WriteLine($"{threads_no} thread(s) ended in {watch.ElapsedMilliseconds} ms.");
                Matrix output_matrix = new Matrix(size, seed_1);
                output_matrix.set_values(output);
                //Console.WriteLine(output_matrix);
            }





            //------------------------------------------------------------Thread-----------------------------------------------------------
            void thread(int threads_no, int rows_perT, List<Row>output)
            {
                List<Thread> threads = new List<Thread>();
                
                for (int i = 0; i < threads_no; i++)
                {
                    int startIndex = i * rows_perT;
                    int endIndex;
                    if (i == threads_no - 1)
                    {
                        endIndex = size;
                    }
                    else
                    {
                        endIndex = (i + 1) * rows_perT;
                    }
                    Thread thread = new Thread(() =>
                    {
                        for (int j = startIndex; j < endIndex; j++)
                        {
                            a.calculate_row(b, j, output);
                        }
                    });
                    threads.Add(thread);
                }

                foreach (var thread in threads)
                {
                    thread.Start();
                }
                foreach (var thread in threads)
                {
                    thread.Join();
                }
            }

            //-------------------------------------------------------Parallel-------------------------------------------------------------------
            void parallel(int threads_no, int rows_perT, List<Row> output)
            {
                ParallelOptions options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = threads_no
                };

                int[] threadUsed = new int[Environment.ProcessorCount];
                Parallel.For(0, threads_no, options, i =>
                {
                    int startIndex = i * rows_perT;
                    int endIndex;
                    if (i == threads_no - 1)
                    {
                        endIndex = size;
                    }
                    else
                    {
                        endIndex = (i + 1) * rows_perT;
                    }

                    for (int j = startIndex; j < endIndex; j++)
                    {
                        a.calculate_row(b, j, output);
                    }
                    threadUsed[Thread.CurrentThread.ManagedThreadId]++;
                });
                //Console.WriteLine(string.Join(" ", threadUsed));
            }


        }

    }
}


