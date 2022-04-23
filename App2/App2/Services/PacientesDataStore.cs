using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.Models;
using SQLiteNetExtensions.Extensions;

namespace Care_Taker.Services
{
    internal class PacientesDataStore : IDataStore<Paciente>
    {
        public Task<Paciente> GetItem(int id, bool Recursive = false)
        {
            return Task.FromResult(App.Connection.GetWithChildren<Paciente>(id,recursive: Recursive));
        }

        public async Task<IEnumerable<Paciente>> GetItems(bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Paciente>(recursive: Recursive));
        }

        public Task<IEnumerable<Paciente>> GetItems(int conditional, bool Recursive = false)
        {
            throw new NotImplementedException();
        }
    }
}
