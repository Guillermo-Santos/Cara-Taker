using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.Models;
using SQLite;

namespace Care_Taker.Services
{
    public class CitasDataStore : IDataStore<Cita>
    {

        private SQLiteAsyncConnection _connection;
        public CitasDataStore(ISQLiteDB db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Cita>();

        }

        public Task<bool> AddItemAsync(Cita item)
        {
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            return Task.FromResult(true);
        }

        public Task<Cita> GetItemAsync(string id)
        {
            return Task.FromResult(new Cita());
        }

        public Task<IEnumerable<Cita>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Cita item)
        {
            return Task.FromResult(true);
        }
    }
}
