using System;

namespace TDD.Uss
{
    public interface Dao<T>
    {
        T? Get(string identifier);
    }

    public class DaoException : Exception
    {
        public DaoException(string message, Exception? cause = null) : base(message, cause)
        {
        }
    }

    public class DaoDictionaryImpl<T> : Dao<T>
    {
        private readonly Dictionary<string, T> repo;

        public DaoDictionaryImpl(Dictionary<string, T>? repo = null)
        {
            this.repo = repo ?? new Dictionary<string, T>();
        }

        public T? Get(string identifier)
        {
            T value;
            if (repo.TryGetValue(identifier, out value))
            {
                return value;
            }
            return default;
        }
    }
}
