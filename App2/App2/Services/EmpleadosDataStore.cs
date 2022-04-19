﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.Models;

namespace Care_Taker.Services
{
    public class EmpleadosDataStore : IDataStore<Empleado>
    {
        public Task<Empleado> GetItemAsync(int id)
        {
            return Task.FromResult(App.Connection.Table<Empleado>().FirstOrDefault(t => t.CodEmpl == id));
        }

        public async Task<IEnumerable<Empleado>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(App.Connection.Table<Empleado>().ToList());
        }

        public Task<IEnumerable<Empleado>> GetItemsAsync(int conditional)
        {
            throw new NotImplementedException();
        }
    }
}