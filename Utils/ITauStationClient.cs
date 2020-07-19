using System.Collections.Generic;
using System.Threading.Tasks;

namespace TauManager.Core.Utils
{
    public interface ITauStationClient
    {
        Task<KeyValuePair<decimal, decimal>> GetItemPriceRange(string slug);
    }
}