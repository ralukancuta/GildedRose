using System.Collections.Generic;
using GildedRose.Domain;

namespace GildedRose.Services
{
    public interface IUpdateQualityService
    {
        void UpdateQuality(IList<Item> items);
        void UpdateQuality(Item item);
    }
}
