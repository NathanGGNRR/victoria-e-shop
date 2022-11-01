//-----------------------------------------------------------------------
// <copyright file="RedisService.cs" company="Diiage">
//    Diiage
// </copyright>
//-----------------------------------------------------------------------
namespace Infrastructure.Services
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Application.Common.Dto;
    using Application.Common.Interfaces;
    using Microsoft.Extensions.Caching.Distributed;
    using Newtonsoft.Json;
    using ServiceStack.Redis;
    
    /// <summary>
    /// Some random shit.
    /// </summary>
    public class RedisService : IRedisService
    {
        /// <summary>
        /// Cache Client.
        /// </summary>
        private IRedisClient _redis;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisClient"/>
        /// </summary>
        /// <param name="cache">Instance of IDistributedCache.</param>
        public RedisService(IRedisClient redis)
        {
            this._redis = redis;
        }

        /// <summary>
        /// Get data from database.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="key">Key of the wanted value.</param>
        /// <returns>Return the given type.</returns>
        public async Task<T> Get<T>(string key)
        {
            var result = this._redis.Get<T>(key);
            if (result != null)
            {
                return result;
            }

            return default;
        }

        /// <summary>
        /// Set an item in the database
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="key">Key to link with the database.</param>
        /// <param name="value">Value to insert in the database.</param>
        /// <returns>Return the given type.</returns>
        public T Set<T>(string key, T value)
        {
            this._redis.Set(key, value);
            return value;
        }

        /// <summary>
        /// Remove the entry in the database.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="key">Key of the entry to remove.</param>
        /// <returns>Return the deleted object.</returns>
        public bool Remove(string key)
        {
         return this._redis.Remove(key);
        }
    }
}
