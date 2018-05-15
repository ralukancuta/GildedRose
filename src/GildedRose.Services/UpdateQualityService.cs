using System.Collections.Generic;
using GildedRose.Domain;

namespace GildedRose.Services
{
    public class UpdateQualityService: IUpdateQualityService
    {
        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                UpdateQuality(item);
            }
        }

        public void UpdateQuality(Item item)
        {
            switch (item.Name)
            {
                case AlgorithmType.Brie:
                {
                    UpdateQualityAlgorithms.BrieUpdateQualityAlgorithm(item);
                    break;
                }
                case AlgorithmType.Sulfuras:
                {
                    return;
                }
                case AlgorithmType.Concert:
                {
                    UpdateQualityAlgorithms.ConcertUpdateQualityAlgorithm(item);
                    break;
                }
                case AlgorithmType.Conjured:
                {
                    UpdateQualityAlgorithms.DefaultUpdateQualityAlgorithm(item, 2);
                    break;
                }
                default:
                {
                    UpdateQualityAlgorithms.DefaultUpdateQualityAlgorithm(item, 1);
                    break;
                }
            }

            item.SellIn--;
        }
    }
}
