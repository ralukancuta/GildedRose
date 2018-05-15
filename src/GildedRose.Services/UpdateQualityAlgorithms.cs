using GildedRose.Domain;

namespace GildedRose.Services
{
    public static class UpdateQualityAlgorithms
    {
        public static void DefaultUpdateQualityAlgorithm(Item item, int decreaseValue)
        {
            DecreaseQuality(item, decreaseValue);

            if (item.SellIn < 0)
            {
                DecreaseQuality(item, decreaseValue);
            }
        }

        public static void BrieUpdateQualityAlgorithm(Item item)
        {
            IncreaseQuality(item, 1);
        }

        public static void ConcertUpdateQualityAlgorithm(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn <= 5)
            {
                IncreaseQuality(item, 3);
            }
            else if (item.SellIn <= 10)
            {
                IncreaseQuality(item, 2);
            }
            else
            {
                IncreaseQuality(item, 1);
            }
        }

        private static void IncreaseQuality(Item item, int increaseValue)
        {
            if (item.Quality <= 50 - increaseValue)
            {
                item.Quality = item.Quality + increaseValue;
            }
            else
            {
                item.Quality = 50;
            }
        }

        private static void DecreaseQuality(Item item, int decreaseValue)
        {
            if (item.Quality >= decreaseValue)
            {
                item.Quality = item.Quality - decreaseValue;
            }
            else
            {
                item.Quality = 0;
            }
        }
    }
}
