using NUnit.Framework;
using NUnit.Framework.Constraints;
using TDD.Fibonacci;

// https://www.wackerart.de/mathematik/big_numbers/fibonacci_numbers.html

namespace TDD.Tests.Fibonacci
{
  public abstract class FibonacciTest {
    protected FibonacciTest(IFibonacci fibonacci) {
      this.fibonacci = fibonacci;
    }

    public IFibonacci fibonacci;

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 2)]
    [TestCase(4, 3)]
    [TestCase(5, 5)]
    [TestCase(6, 8)]
    public void Calc_shouldPassForSmallIndices(int index, int expected) {
      int actual = fibonacci.Calculate(index);
      Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(19, 4_181)]
    [TestCase(27, 196_418)]
    public void Calc_shouldPassForMediumIndices(int index, int expected) {
      int actual = fibonacci.Calculate(index);
      Assert.That(actual, Is.EqualTo(expected));
    }


    [TestCase(-1, "Index must be >= 0")]
    [TestCase(47, "Index must be <= 46")]
    public void Calc_shouldFail(int index, string expected) {
      ArgumentException e = Assert.Throws<ArgumentException>(() => fibonacci.Calculate(index));  
      Assert.That(e.Message, Is.EqualTo(expected));
    }
  }

  public class FibonacciLoopImplTest : FibonacciTest {
    public FibonacciLoopImplTest() : base(new FibonacciLoopImpl()) 
    {}

    [TestCase(45, 1_134_903_170)]
    [TestCase(46, 1_836_311_903)]
    public void Calc_shouldPassForLargeIndices(int index, int expected) {
      int actual = fibonacci.Calculate(index);
      Assert.That(actual, Is.EqualTo(expected));
    }
  }

  public class FibonacciRecursiveImplTest : FibonacciTest {
    public FibonacciRecursiveImplTest() : base(new FibonacciRecursiveImpl()) 
    {}
  }


}
