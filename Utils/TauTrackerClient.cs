using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TauManager.Models;

namespace TauManager.Utils
{
    public class TauTrackerClient : ITauHeadClient
    {
        public const string ItemUrlBase = "https://tracker.tauguide.de/v1/item/by-slug/";
        public const string UrlBase = "https://taustation.space/static/images/item/";

        public string UrlBaseEx {
            get{
                return ItemUrlBase;
            }
        }

        public IDictionary<string, Item> BulkParseItems(string jsonContent)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Item> GetItemData(string url)
        {
            Item item = null;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var responseObject = JsonConvert.DeserializeObject<TauTrackerItem>(await result.Content.ReadAsStringAsync());
                item = _parseItemData(responseObject);
            }
            return item;
        }

        private Item _parseItemData(TauTrackerItem responseObject)
        {
            Item item;
            Item.ItemType itemType;
            var itemTypeParseResult = Enum.TryParse<Item.ItemType>(responseObject.type.Replace(" ", ""), true, out itemType);
            if (!itemTypeParseResult) return null;
            Item.ItemRarity ItemRarity;
            var itemRarityParseResult = Enum.TryParse<Item.ItemRarity>(responseObject.rarity, true, out ItemRarity);
            if (!itemRarityParseResult) return null;
            item = new Item{
                Type = itemType,
                Name = responseObject.name,
                ImageUrl = UrlBase + responseObject.slug + ".png",
                Tier = responseObject.tier,
                Rarity = ItemRarity,
                Price = responseObject.value,
                Slug = responseObject.slug,
                Weight = responseObject.mass_kg
            };
            if (itemType == Item.ItemType.Armor)
            {
                item.Piercing = responseObject.piercing_defense;
                item.Impact = responseObject.impact_defense;
                item.Energy = responseObject.energy_defense;
            }
            if (itemType == Item.ItemType.Weapon)
            {
                item.Piercing = responseObject.piercing_damage;
                item.Impact = responseObject.impact_damage;
                item.Energy = responseObject.energy_damage;
                item.Accuracy = responseObject.accuracy;
                item.HandToHand = responseObject.hand_to_hand ?? false;
                Item.ItemWeaponType weaponType;
                var weaponTypeParseResult = Enum.TryParse<Item.ItemWeaponType>(responseObject.weapon_type.FirstCharToUpper().Replace(" ",""), false, out weaponType);
                if (!weaponTypeParseResult) return null;
                item.WeaponType = weaponType;
                item.WeaponRange = responseObject.weapon_range == "Long" ? Item.ItemWeaponRange.Long : Item.ItemWeaponRange.Short;
            }
            return item;
         }

        public string UrlFromSlug(string slug)
        {
            return ItemUrlBase + slug;
        }
    }
}