//-----------------------------------------------------------------------
// <copyright file="IRedisService.cs" company="Diiage">
//    Diiage
// </copyright>
//-----------------------------------------------------------------------
namespace Application.Common.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of the database access.
    /// </summary>
    public interface IRedisService
    {
        /// <summary>
        /// Get data from the database.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="key">Key of the wanted data.</param>
        /// <returns>Return a task of the given type.</returns>
        Task<T> Get<T>(string key);

        /// <summary>
        /// Set data in the database.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="key">Key to set in the database.</param>
        /// <param name="value">Value to set in the database.</param>
        /// <returns>Return a task of the given type.</returns>
        T Set<T>(string key, T value);

        /// <summary>
        /// Remove data from the database.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="key">Key of the value to delete.</param>
        /// <returns>Return a task of the given type.</returns>
        public bool Remove(string key);
    }
}
