using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Care_Taker.Models;
using SQLiteNetExtensions.Extensions;

namespace Care_Taker.Services
{
    public class ExamenesCitaDataStore : IDataStore<Examen_Cita>
    {
        public Task<Examen_Cita> GetItem(int id, bool Recursive = false)
        {
            return Task.FromResult(App.Connection.GetWithChildren<Examen_Cita>(id, recursive: Recursive));
        }

        public async Task<IEnumerable<Examen_Cita>> GetItems(bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Examen_Cita>(recursive: Recursive));
        }

        public async  Task<IEnumerable<Examen_Cita>> GetItems(int conditional, bool Recursive = false)
        {
            return await Task.FromResult(App.Connection.GetAllWithChildren<Examen_Cita>(t => t.CodCita == conditional, recursive: Recursive));
        }
    }
}
