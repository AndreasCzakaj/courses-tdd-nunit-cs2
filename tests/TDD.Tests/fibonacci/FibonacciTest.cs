using NUnit.Framework;
using TDD.Fibonacci;

namespace TDD.Tests.Fibonacci
{
    public class FibonacciTest
    {

        [SetUp]
        public void beforeEach()
        {
        }

        [Test]
        public void ShouldYield0For0()
        {
            // Arrange  ("given")
            TDD.Fibonacci.Fibonacci fibonacci = new TDD.Fibonacci.Fibonacci();
            int index = 0;

            // Act      ("when")
            int actual = fibonacci.Calc(index);

            // Assert   ("then")
            Assert.That(actual, Is.EqualTo(0));
        }


        [Test]
        [Ignore("ToDo")]
        public void ShouldFailForMinus1()
        {
        }


        [Test]
        [Ignore("ToDo")]
        public void ShouldFailFor47()
        {
        }

    /*[TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 2)]
    [TestCase(5, 5)]
    [TestCase(6, 8)]
    [TestCase(7, 13)]
    [TestCase(19, 4_181)]
    [TestCase(30, 832_040)]
    public void shouldYieldFibonacci(int index, int expected)
    {
      // Act (when)
      int actual = fibonacci.Calculate(index);

      // Assert (then)
      Assert.That(actual, Is.EqualTo(expected));
    }*/

    /*[TestCase(-1, "Index must not be negative")]
    [TestCase(47, "Indext must not be greater than 46")]
    public void shouldThrowError(int index, string expected)
    {
      // Act (when)
      ArgumentException e = Assert.Throws<ArgumentException>(() => fibonacci.Calculate(index));

      // Assert (then)
      Assert.That(e.Message, Is.EqualTo(expected));
    }*/
  }
}