using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.Models;
using SQLiteNetExtensions.Extensions;

namespace Care_Taker.Services
{
    public class EmpleadosDataStore : IDataStore<Empleado>
    {
        public Task<Empleado> GetItem(int id, bool Recursive = false)
        {
            return Task.FromResult(App.Connection.GetWithChildren<Empleado>(id, recursive: Recursive));
        }

        public async Task<IEnumerable<Empleado>> GetItems(bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Empleado>(recursive: Recursive));
        }

        public Task<IEnumerable<Empleado>> GetItems(int conditional, bool Recursive = false)
        {
            throw new NotImplementedException();
        }
    }
}
