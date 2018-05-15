using GildedRose.Domain;
using Xunit;

namespace GildedRose.Tests
{
    public class TestConjuredUpdateTests : TestBase
    {
        [Theory]
        [InlineData(4, 7)]
        [InlineData(12, 5)]
        public void TestConjured(int sellIn, int quality)
        {
            var item = new Item {Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality};

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality - 2);
        }

        [Theory]
        [InlineData(15, 2)]
        [InlineData(0, 1)]
        [InlineData(2, 0)]
        public void TestConjuredQualityTo0(int sellIn, int quality)
        {
            var item = new Item
            {
                Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality};

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == 0);
        }

        [Theory]
        [InlineData(-2, 7)]
        [InlineData(-1, 6)]
        public void TestConjuredSellInLowerThan0(int sellIn, int quality)
        {
            var item = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = sellIn,
                Quality = quality
            };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality - 4);
        }

        [Theory]
        [InlineData(-2, 4)]
        [InlineData(-2, 3)]
        [InlineData(-1, 2)]
        [InlineData(-1, 1)]
        [InlineData(-3, 0)]
        public void TestConjuredSellInLowerThan0QualityTo0(int sellIn, int quality)
        {
            var item = new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = sellIn,
                Quality = quality
            };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == 0);
        }
    }
}