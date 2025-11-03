namespace TDD.Fibonacci
{
    public interface IFibonacci
    {
        public int Calculate(int index);
    }

    public abstract class FibonacciBaseImpl : IFibonacci
    {
        public int Calculate(int index)
        {
            // validation
            if (index < 0) {
                throw new ArgumentException("Index must be >= 0");
            }
            if (index > 46) {
                throw new ArgumentException("Index must be <= 46");
            }

            return CalculateImpl(index);
        }

        protected abstract int CalculateImpl(int index);
    }

    public class FibonacciLoopImpl : FibonacciBaseImpl
    {
        protected override int CalculateImpl(int index)
        {
            if (index < 2) {
                return index;
            }

            int lastBut1 = 0;
            int last = 1;
            int result = 0;

            for (int i = 2; i <= index; i++)
            {
                result = last + lastBut1;
                lastBut1 = last;
                last = result;
            }

            return result;
        }
    }

    public class FibonacciRecursiveImpl : FibonacciBaseImpl
    {
        protected override int CalculateImpl(int index)
        {
            if (index < 2) {
                return index;
            }
            return CalculateImpl(index - 1) + CalculateImpl(index - 2);
        }
    }
}