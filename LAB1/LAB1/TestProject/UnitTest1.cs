using LAB1;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Helpers;
using System.Runtime.Intrinsics.Wasm;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Did_return()
        {
            int number = 10;
            int seed = 1;
            int capacity = 10;
            Problem problem = new Problem(number, seed);
            Result result = problem.solve(capacity);
            List<Item> solution = result.Packed;

            Assert.IsNotNull(solution);
            Assert.IsTrue(solution.Count > 0);


        }
        [TestMethod]
        public void Is_empty()
        {
            int number = 10;
            int seed = 1;
            int capacity = 0;
            Problem problem = new Problem(number, seed);
            Result result = problem.solve(capacity);
            List<Item> solution = result.Packed;

            Assert.IsNotNull(solution);
            Assert.IsTrue(solution.Count == 0);
        }

        [TestMethod]
        public void Different_order()
        {
            int number = 10;
            int seed = 1;
            int capacity = 7;
            int expected_value = 20;
            int expected_weight = 7;
            int no_of_items = 3;
            Problem problem = new Problem(number, seed);
            List<Item> different_order = problem.Items_list.OrderByDescending(item =>item.Weight).ToList<Item>();
            problem.Items_list = different_order;
            Result result = problem.solve(capacity);
            List<Item> solution = result.Packed;

            Assert.IsNotNull(solution);
            Assert.AreEqual(result.Total_weight, expected_weight);
            Assert.AreEqual(result.Total_value, expected_value);
            Assert.AreEqual(solution.Count, no_of_items);



        }
        [TestMethod]
        public void Is_correct()
        {
            int number = 10;
            int seed =1;
            int capacity = 7;
            int expected_value = 20;
            int expected_weight = 7;
            int no_of_items = 3;
            Problem problem = new Problem(number, seed);
            Result result = problem.solve(capacity);
            List<Item> solution = result.Packed;

            Assert.IsNotNull(solution);
            Assert.AreEqual(result.Total_weight, expected_weight);
            Assert.AreEqual(result.Total_value, expected_value);
            Assert.AreEqual(solution.Count, no_of_items);

        }
        [TestMethod]
        public void Many_items()
        {
            int number = 10000000;
            int seed = 222;
            int capacity = 5000;
            Problem problem = new Problem(number, seed);
            Result result = problem.solve(capacity);
            List<Item> solution = result.Packed;

            Assert.IsNotNull(solution);
            Assert.IsTrue(solution.Count > 0);
        }

        [TestMethod]
        public void Every_item()
        {
            int number = 10;
            int seed = 1;
            int capacity = 101;
            Problem problem = new Problem(number, seed);
            Result result = problem.solve(capacity);
            List<Item> solution = result.Packed;

            Assert.IsNotNull(solution);
            Assert.IsTrue(result.Total_weight<capacity);
        }

        [TestMethod]
        public void Negative_number()
        {
            int number = -1;
            int seed = 1;
            int capacity = 10;
            Problem problem = new Problem(number, seed);
            Result result = problem.solve(capacity);
            List<Item> solution = result.Packed;

            Assert.IsNotNull(solution);
            Assert.AreEqual(solution.Count, 0);
        }

        [TestMethod]
        public void Wrong_random()
        {
            int number = 10;
            int seed = 1;
            int capacity = 10;
            Random random = new Random(seed);

            Problem problem = new Problem(number, seed);
            foreach(Item item in problem.Items_list)
            {
                item.Weight = random.Next(100, 200);
                item.Price = random.Next(100, 200);
            }

            Result result = problem.solve(capacity);
            List<Item> solution = result.Packed;
            Assert.IsNotNull(solution);
            Assert.AreEqual(solution.Count, 0);
        }


    }
}