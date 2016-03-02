using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    public abstract class BaseInMemoryRepository<T> where T : IDomain
    {
        private readonly Dictionary<int, T> dictionary = new Dictionary<int, T>();


        public IEnumerable<T> FindAll()
        {
            return dictionary.Values;
        }

        public T FindById(int id)
        {
            T result;
            var success = dictionary.TryGetValue(id, out result);
            return success ? result : default(T);

        }

        public T Save(T data)
        {
            if (data != null)
            {
                lock (dictionary)
                {
                    if (!data.DomainId.HasValue)
                    {
                        data.DomainId = dictionary.Count + 1;
                    }
                    dictionary[data.DomainId.Value] = data;
                }
            }
            return data;
        }
    }
}
