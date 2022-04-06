using Care_Taker.Models;
using System;
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
                new Item { Id = Guid.NewGuid().ToString(), Text = "Alejandro Vegas", Description="Ingreso: 08/06/2018     Sangre: O+." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Luis Rogers", Description="Ingreso: 02/10/2019     Sangre: O+." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Miguel Santos", Description="Ingreso: 08/06/2019     Sangre: O-." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Juan Molina", Description="Ingreso: 16/03/2020     Sangre: O+." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Christofer Vargas", Description="Ingreso: 26/11/2022     Sangre: O+." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}