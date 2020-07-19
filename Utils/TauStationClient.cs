using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TauManager.Core.Utils
{
    public class TauStationClient : ITauStationClient
    {
        private readonly Regex _priceRegex = new Regex("\"currency\">([0-9.]+)[\\s-]+([0-9.]+)");
        public async Task<KeyValuePair<decimal, decimal>> GetItemPriceRange(string slug)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://alpha.taustation.space/item/" + slug);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                // Obligatory link: https://stackoverflow.com/a/1732454/625594
                var isMatch = _priceRegex.IsMatch(content);
                if (isMatch)
                {
                    var match = _priceRegex.Match(content);
                    decimal lowerValue, upperValue;
                    decimal.TryParse(match.Groups[1].Value, out lowerValue);
                    decimal.TryParse(match.Groups[2].Value, out upperValue);
                    return new KeyValuePair<decimal, decimal>(lowerValue, upperValue);
                }
            }
            return new KeyValuePair<decimal, decimal>(0,0);
        }
    }
}