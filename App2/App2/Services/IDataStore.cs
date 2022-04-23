using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Care_Taker.Services
{
    /// <summary>
    /// Interfaz para los servicios de manejo de datos de las tablas de la base de datos
    /// </summary>
    /// <typeparam name="T">Tipo/Modelo de la tabla de la base de datos</typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// Insert an item of type T on table of type T
        /// </summary>
        /// <param name="item">item of type T to be inserted</param>
        /// <returns></returns>
        async Task<bool> AddItem(T item)
        {
            App.Connection.Insert(item);
            await UpdateItem(item);
            return await Task.FromResult(true);
        }
        /// <summary>
        /// Update an item of type <typeparamref name="T"/> on table of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="item">item of type <typeparamref name="T"/> to be updated</param>
        /// <returns></returns>
        async Task<bool> UpdateItem(T item)
        {
            App.Connection.UpdateWithChildren(item);
            return await Task.FromResult(true);
        }
        /// <summary>
        /// Delete an item of type <typeparamref name="T"/>
        /// </summary>
        /// <param name="id"> id of the item of type <typeparamref name="T"/> to be deleted</param>
        /// <returns></returns>
        async Task<bool> DeleteItem(int id)
        {
            App.Connection.Delete<T>(id);
            return await Task.FromResult(true);
        }
        /// <summary>
        /// get an item of type <typeparamref name="T"/> of table <typeparamref name="T"/>
        /// </summary>
        /// <param name="id">id of the item of type <typeparamref name="T"/> to be getted</param>
        /// <param name="Recursive"> used to indicate if you want to get the childrens of the chiildrens <typeparamref name="T"/></param>
        /// <returns>
        ///     An item of the designed table
        /// </returns>
        Task<T> GetItem(int id, bool Recursive = false);
        /// <summary>
        /// get an <see cref="IEnumerable{T}"/> of table <typeparamref name="T"/>
        /// </summary>
        /// <param name="Recursive"> used to indicate if you want to get the childrens of the chiildrens <typeparamref name="T"/></param>
        /// <returns>
        ///     A list of items of the designed table
        /// </returns>
        Task<IEnumerable<T>> GetItems(bool Recursive = false);
        /// <summary>
        /// get an <see cref="IEnumerable{T}"/> of table <typeparamref name="T"/> if <paramref name="conditional"/> exist
        /// </summary>
        /// <param name="conditional"> conditional to get data <typeparamref name="T"/></param>
        /// <param name="Recursive"> used to indicate if you want to get the childrens of the chiildrens <typeparamref name="T"/></param>
        /// <returns>
        ///     A list of items of the designed table
        /// </returns>
        Task<IEnumerable<T>> GetItems(int conditional, bool Recursive = false);
    }
}
