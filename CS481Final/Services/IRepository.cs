using System.Collections.Generic;
using System.Threading.Tasks;
using CS481Final.Models;

namespace CS481Final.Services
{
    public interface IRepository
    {
        Task<IList<IndividualItem>> GetItem();

        Task<IList<IndividualItem>> GetItem(int numberOfItems);

        Task AddItem(IndividualItem newItem);

        Task RemoveItem(IndividualItem removeItem);
    }
}