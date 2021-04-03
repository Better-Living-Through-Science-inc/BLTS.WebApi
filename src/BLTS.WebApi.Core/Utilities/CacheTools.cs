using System;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace BLTS.WebApi.Utilities
{
    public static class AsyncCacheExtensions
    {
        /// <summary>
        /// either returns an exesiting cache value or it creates a new one and returns the value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="valueFactory"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public static T AddOrGetExistingCacheEntry<T>(this ObjectCache cache, string key, Func<T> valueFactory, CacheItemPolicy policy)
        {
            var newValue = new Lazy<T>(valueFactory);
            var oldValue = (Lazy<T>)cache.AddOrGetExisting(key, newValue, policy);

            try
            {
                return oldValue != null ? oldValue.Value : newValue.Value;
            }
            catch
            {
                cache.Remove(key);
                throw;
            }
        }
    }

    public class AsyncLazy<T> : Lazy<Task<T>>
    {
        public AsyncLazy(Func<T> valueFactory) :
            base(() => Task.Factory.StartNew(valueFactory))
        {
        }

        public AsyncLazy(Func<Task<T>> taskFactory) :
            base(() => Task.Factory.StartNew(taskFactory).Unwrap())
        {
        }
    }
}
