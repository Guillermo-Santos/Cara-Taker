using Care_Taker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;

namespace Care_Taker.Services
{
    public class UsuariosDataStore : IDataStore<Usuario>
    {
        public Task<Usuario> GetItem(int id, bool Recursive = false)
        {
            return Task.FromResult(App.Connection.GetWithChildren<Usuario>(id,recursive: Recursive));
        }

        public async Task<IEnumerable<Usuario>> GetItems(bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Usuario>(recursive: Recursive));
        }
        public Task<IEnumerable<Usuario>> GetItems(int condition, bool Recursive = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
