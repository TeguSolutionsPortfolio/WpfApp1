using NUnit.Framework;

namespace SolutionTests
{
    public class Task2Tests
    {
        // [People Group] [Car Seats] [Expected Required Cars]

        [TestCase(new[] { 1 }, new[] { 1 }, 1)]
        [TestCase(new[] { 1, 1 }, new[] { 1 }, 1)]
        [TestCase(new[] { 2 }, new[] { 1, 1 }, 2)]
        [TestCase(new[] { 2, 4, 1 }, new[] { 3, 4, 7 }, 1)]
        public void CarSeats_2_People_2_Returns_1(int[] people, int[] carSeats, int requiredCars)
        {
            var result = Solutions.Solutions.solution2(people, carSeats);
            Assert.AreEqual(requiredCars, result);
        }
    }
}