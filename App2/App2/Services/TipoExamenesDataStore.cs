using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Care_Taker.Models;
using SQLiteNetExtensions.Extensions;
using System.Threading.Tasks;

namespace Care_Taker.Services
{
    public class TipoExamenesDataStore : IDataStore<Tipo_Examen>
    {
        public Task<Tipo_Examen> GetItem(int id, bool Recursive = false)
        {
            return Task.FromResult<Tipo_Examen>(App.Connection.GetWithChildren<Tipo_Examen>(id, recursive: Recursive));
        }

        public async Task<IEnumerable<Tipo_Examen>> GetItems(bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Tipo_Examen>(recursive: Recursive));
        }

        public Task<IEnumerable<Tipo_Examen>> GetItems(int conditional, bool Recursive = false)
        {
            throw new NotImplementedException();
        }
    }
}
