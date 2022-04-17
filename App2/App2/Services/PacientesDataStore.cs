using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.Models;

namespace Care_Taker.Services
{
    internal class PacientesDataStore : IDataStore<Paciente>
    {
        public Task<Paciente> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Paciente>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(App.Connection.Table<Paciente>().ToListAsync().Result);
        }

        public Task<IEnumerable<Paciente>> GetItemsAsync(int conditional)
        {
            throw new NotImplementedException();
        }
    }
}
