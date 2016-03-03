using System;
using System.Collections.Generic;
using Common.Domain;

namespace Common.Repository
{
    /// <summary>
    /// In memory dictionary implementation of a repository using Guid string as key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseInMemoryRepository<T> where T : IDomain
    {
        protected readonly Dictionary<string, T> dictionary = new Dictionary<string, T>();


        public IEnumerable<T> FindAll()
        {
            return dictionary.Values;
        }

        public T FindById(string id)
        {
            T result;
            var success = dictionary.TryGetValue(id, out result);
            return success ? result : default(T);

        }

        public T Save(T data)
        {
            if (data != null)
            {
                if (data.DomainId == null)
                {
                    data.DomainId = Guid.NewGuid().ToString();
                }
                dictionary[data.DomainId] = data;
            }
            return data;
        }

    }
}
