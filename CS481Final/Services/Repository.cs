using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CS481Final.Models;

namespace CS481Final.Services
{
    public class Repository : IRepository
    {
        IList<IndividualItem> itemFromSomeDataSource = null;

        public Repository()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Repository)}:  ctor");
        }

        // Method summary provided in interface.
        public async Task<IList<IndividualItem>> GetItem()
        {
            await Task.Delay(500);

            return itemFromSomeDataSource;
        }

        public async Task<IList<IndividualItem>> GetItem(int numberOfItems)
        {
            itemFromSomeDataSource = new List<IndividualItem>();

            for (int i = 0; i < numberOfItems; i++)
            {
                IndividualItem newItem = new IndividualItem()
                {
                    Total = $"{i}"
                };

                itemFromSomeDataSource.Add(newItem);
            }

           await Task.Delay(500);

            return itemFromSomeDataSource;
        }

        // Method summary provided in interface.
        public async Task AddItem(IndividualItem newItem)
        {
            if (itemFromSomeDataSource == null)
            {
                itemFromSomeDataSource = new List<IndividualItem>();
            }
            itemFromSomeDataSource.Add(newItem);
            await Task.Delay(500);
        }

        public async Task RemoveItem(IndividualItem removeItem)
        {
            if (itemFromSomeDataSource == null)
            {
            }
            itemFromSomeDataSource.Remove(removeItem);
            await Task.Delay(500);
        }
    }
}