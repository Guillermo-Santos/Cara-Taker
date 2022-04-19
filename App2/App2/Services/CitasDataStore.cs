using Care_Taker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using System.Linq;

namespace Care_Taker.Services
{
    public class CitasDataStore : IDataStore<Cita>
    {
        public Task<bool> AddItemAsync(Cita item)
        {
            App.Connection.Insert(item);
            App.Connection.UpdateWithChildren(item);
            //App.Connection.InsertWithChildren(item, recursive: true);
            return Task.FromResult(true);
        }
        public Task<Cita> GetItemAsync(int id)
        {
            return Task.FromResult(App.Connection.GetWithChildren<Cita>(id));
        }
        
        public async Task<IEnumerable<Cita>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Cita>());

        }

        public async Task<IEnumerable<Cita>> GetItemsAsync(int conditional)
        {
            var Citas = await GetItemsAsync(true);
            var cita = from cta in Citas where cta.CodEmpl == conditional select cta;
            return await Task.FromResult(cita);
            //return await Task.FromResult(App.Connection.GetAllWithChildren<Cita>(t => t.CodEmpl == conditional));
        }
    }
}
