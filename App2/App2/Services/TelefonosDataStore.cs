using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Care_Taker.Models;
using SQLiteNetExtensions.Extensions;
using System.Threading.Tasks;

namespace Care_Taker.Services
{
    public class TelefonosDataStore : IDataStore<Telefono>
    {
        public Task<Telefono> GetItem(int id, bool Recursive = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Telefono>> GetItems(bool Recursive = false)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Telefono>> GetItems(int conditional, bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Telefono>(t => t.CodPers ==conditional, recursive: Recursive));
        }
    }
}
