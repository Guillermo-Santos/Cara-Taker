using Care_Taker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using System.Linq;

namespace Care_Taker.Services
{
    public class CitasDataStore : IDataStore<Cita>
    {
        public Task<Cita> GetItem(int id, bool Recursive = false)
        {
            return Task.FromResult(App.Connection.GetWithChildren<Cita>(id, recursive: Recursive));
        }
        
        public async Task<IEnumerable<Cita>> GetItems(bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Cita>(recursive: Recursive));

        }

        public async Task<IEnumerable<Cita>> GetItems(int conditional, bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Cita>(t => t.CodEmpl == conditional, recursive: Recursive));
        }
    }
}
