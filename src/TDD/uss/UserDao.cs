using System;
using System.IO;
using System.Text;
using System.Text.Json;

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

    public class DaoFileImpl<T> : Dao<T>
    {
        private readonly string _rootPath;

        public DaoFileImpl(string rootPath)
        {
            this._rootPath = rootPath;
        }

        public T? Get(string identifier)
        {
            var filePath = calcFilePath(identifier);
            if (File.Exists(filePath))
            {
                try
                {
                    var json = File.ReadAllText(filePath);
                    var res = JsonSerializer.Deserialize<T>(json);
                    return res;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new DaoException("DaoFileImpl.get failed");
                }
            }
            return default;
        }

        private string calcFilePath(string identifier)
        {
            var filePath = Path.Combine(_rootPath, identifier);
            filePath = filePath + ".json";
            return filePath;
        }

        public T Save(T item, string identifier)
        {
            var filePath = calcFilePath(identifier);
            try
            {
                var serialized = JsonSerializer.Serialize(item);
                File.WriteAllText(filePath, serialized, Encoding.UTF8);
                return item;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new DaoException("DaoFileImpl.Save failed");
            }
        }
    }
    
    
}
