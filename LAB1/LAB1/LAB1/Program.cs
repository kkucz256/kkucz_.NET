namespace LAB1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of items: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the seed: ");
            int seed = int.Parse(Console.ReadLine());

            Problem problem = new Problem(number, seed);
            Console.WriteLine(problem);

            Console.WriteLine("Enter the capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            Result result = problem.solve(capacity);
            Console.WriteLine(result);


        }
    }
}