
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Care_Taker.Services
{
    public interface IDataStore<T>
    {
        /// <summary>
        /// Insert an item of type T on table of type T
        /// </summary>
        /// <param name="item">item of type T to be inserted</param>
        /// <returns></returns>
        Task<bool> AddItemAsync(T item)
        {
            App.Connection.InsertAsync(item);
            return Task.FromResult(true);
        }
        /// <summary>
        /// Update an item of type <typeparamref name="T"/> on table of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="item">item of type <typeparamref name="T"/> to be updated</param>
        /// <returns></returns>
        Task<bool> UpdateItemAsync(T item)
        {
            App.Connection.UpdateAsync(item);
            return Task.FromResult(true);
        }
        /// <summary>
        /// Delete an item of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="id"> id of the item of type <typeparamref name="T"/> to be deleted</param>
        /// <returns></returns>
        Task<bool> DeleteItemAsync(int id)
        {
            App.Connection.DeleteAsync<T>(id);
            return Task.FromResult(true);
        }
        /// <summary>
        /// get an item of type <typeparamref name="T"/> of table <typeparamref name="T"/>
        /// </summary>
        /// <param name="id">id of the item of type <typeparamref name="T"/> to be getted</param>
        /// <returns></returns>
        Task<T> GetItemAsync(int id);
        /// <summary>
        /// get an <see cref="IEnumerable{T}"/> of table <typeparamref name="T"/>
        /// </summary>
        /// <param name="forceRefresh"> used to say if we will force a refres on data of table <typeparamref name="T"/></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        /// <summary>
        /// get an <see cref="IEnumerable{T}"/> of table <typeparamref name="T"/> if <paramref name="conditional"/> exist
        /// </summary>
        /// <param name="conditional"> conditional to get data <typeparamref name="T"/></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsAsync(int conditional);
    }
}
