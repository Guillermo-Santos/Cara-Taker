using System;
using System.Collections.Generic;
using System.Text;
using Care_Taker.Models;
using SQLiteNetExtensions.Extensions;
using System.Threading.Tasks;

namespace Care_Taker.Services
{
    public class EmailsDataStore : IDataStore<Email>
    {
        public Task<Email> GetItem(int id, bool Recursive = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Email>> GetItems(bool Recursive = false)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Email>> GetItems(int conditional, bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Email>(t => t.CodPers == conditional, recursive: Recursive));
        }
    }
}
