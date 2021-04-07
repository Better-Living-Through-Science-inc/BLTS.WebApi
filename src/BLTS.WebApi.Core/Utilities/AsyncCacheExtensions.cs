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
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="valueFactory"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public static TEntity AddOrGetExistingCacheEntry<TEntity>(this ObjectCache cache, string key, Func<TEntity> valueFactory, CacheItemPolicy policy)
        {
            Lazy<TEntity> newValue = new Lazy<TEntity>(valueFactory);
            Lazy<TEntity> oldValue = (Lazy<TEntity>)cache.AddOrGetExisting(key, newValue, policy);

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

    public class AsyncLazy<TEntity> : Lazy<Task<TEntity>>
    {
        public AsyncLazy(Func<TEntity> valueFactory) :
            base(() => Task.Factory.StartNew(valueFactory))
        {
        }

        public AsyncLazy(Func<Task<TEntity>> taskFactory) :
            base(() => Task.Factory.StartNew(taskFactory).Unwrap())
        {
        }
    }
}
