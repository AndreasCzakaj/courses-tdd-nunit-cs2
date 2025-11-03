using NUnit.Framework;
using TDD.Fibonacci;

namespace TDD.Tests.Fibonacci
{
    public class FibonacciTest
    {

        [Test]
        public void ShouldYield0For0()
        {
            // Arrange  ("given")
            TDD.Fibonacci.Fibonacci fibonacci = new TDD.Fibonacci.Fibonacci();
            int index = 0;

            // Act      ("when")
            int actual = fibonacci.Calc(index);

            // Assert   ("then")
            int expected = 0;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("ToDo")]
        public void ShouldYield1For1() {}

        [Test]
        [Ignore("ToDo")]
        public void ShouldYield1For2() {}

        [Test]
        [Ignore("ToDo")]
        public void ShouldYield2For3() {}

        [Test]
        [Ignore("ToDo")]
        public void ShouldYield3For4() {}

        [Test]
        [Ignore("ToDo")]
        public void ShouldYield5For5() {}

        [Test]
        [Ignore("ToDo")]
        public void ShouldYield8For6() {}


        [Test]
        [Ignore("ToDo")]
        public void ShouldYield4_181For19() {}


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

  }
}