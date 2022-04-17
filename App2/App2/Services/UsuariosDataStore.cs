using Care_Taker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Care_Taker.Services
{
    public class UsuariosDataStore : IDataStore<Usuario>
    {
        public Task<Usuario> GetItemAsync(int id)
        {
            return Task.FromResult(App.Connection.Table<Usuario>().FirstOrDefaultAsync(t => t.CodUser == id).Result);
        }

        public async Task<IEnumerable<Usuario>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(App.Connection.Table<Usuario>().ToListAsync().Result);
        }
        public Task<IEnumerable<Usuario>> GetItemsAsync(int condition)
        {
            throw new System.NotImplementedException();
        }
    }
}
