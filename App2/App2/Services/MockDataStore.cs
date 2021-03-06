using Care_Taker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Care_Taker.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = 1, Text = "Alejandro Vegas", Description="Ingreso: 08/06/2018     Sangre: O+." },
                new Item { Id = 2, Text = "Luis Rogers", Description="Ingreso: 02/10/2019     Sangre: O+." },
                new Item { Id = 3, Text = "Miguel Santos", Description="Ingreso: 08/06/2019     Sangre: O-." },
                new Item { Id = 4, Text = "Juan Molina", Description="Ingreso: 16/03/2020     Sangre: O+." },
                new Item { Id = 5, Text = "Christofer Vargas", Description="Ingreso: 26/11/2022     Sangre: O+." }
            };
        }

        public async Task<bool> AddItem(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItem(Item item)
        {
            var oldItem = items.Where((arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItem(int id)
        {
            var oldItem = items.Where((arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItem(int id, bool Recursive = false)
        {
            return await Task.FromResult(items[0]);
        }

        public async Task<IEnumerable<Item>> GetItems(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public Task<IEnumerable<Item>> GetItems(int conditional, bool Recursive = false)
        {
            throw new System.NotImplementedException();
        }
    }
}