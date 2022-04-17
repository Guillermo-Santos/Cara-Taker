using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.Models;

namespace Care_Taker.Services
{
    public class TipoCitasDataStore : IDataStore<Tipo_Cita>
    {
        public Task<Tipo_Cita> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tipo_Cita>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(App.Connection.Table<Tipo_Cita>().ToListAsync().Result);
        }

        public Task<IEnumerable<Tipo_Cita>> GetItemsAsync(int conditional)
        {
            throw new NotImplementedException();
        }
    }
}
