using Care_Taker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Care_Taker.Services
{
    public class CitasDataStore : IDataStore<Cita>
    {
        public Task<Cita> GetItemAsync(int id)
        {
            return Task.FromResult(App.Connection.Table<Cita>().FirstOrDefaultAsync(t => t.CodCita == id).Result);
        }
        
        public async Task<IEnumerable<Cita>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(App.Connection.Table<Cita>().ToListAsync().Result);
        }

        public async Task<IEnumerable<Cita>> GetItemsAsync(int conditional)
        {
            return await Task.FromResult(App.Connection.Table<Cita>().Where(t => t.CodEmpl == conditional).ToListAsync().Result);
        }
    }
}
