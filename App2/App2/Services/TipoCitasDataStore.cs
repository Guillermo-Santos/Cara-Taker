using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.Models;
using SQLiteNetExtensions.Extensions;

namespace Care_Taker.Services
{
    public class TipoCitasDataStore : IDataStore<Tipo_Cita>
    {
        public Task<Tipo_Cita> GetItem(int id, bool Recursive = false)
        {
            return Task.FromResult(App.Connection.GetWithChildren<Tipo_Cita>(id, recursive: Recursive));
        }

        public async Task<IEnumerable<Tipo_Cita>> GetItems(bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Tipo_Cita>(recursive: Recursive));
        }

        public Task<IEnumerable<Tipo_Cita>> GetItems(int conditional, bool Recursive = false)
        {
            throw new NotImplementedException();
        }
    }
}
