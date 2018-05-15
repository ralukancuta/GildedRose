using GildedRose.Domain;
using Xunit;

namespace GildedRose.Tests
{
    public class TestElixirUpdateTests : TestBase
    {
        [Theory]
        [InlineData(7, 4)]
        [InlineData(1, 5)]
        public void TestElixir(int sellIn, int quality)
        {
            var item = new Item { Name = "Elixir of the Mongoose", SellIn = sellIn, Quality = quality };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality - 1);
        }

        [Theory]
        [InlineData(-2, 7)]
        [InlineData(-3, 3)]
        public void TestElixirSellInLowerThan0(int sellIn, int quality)
        {
            var item = new Item { Name = "Elixir of the Mongoose", SellIn = sellIn, Quality = quality };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality - 2);
        }

        [Theory]
        [InlineData(6, 0)]
        [InlineData(12, 1)]
        public void TestElixirQualityTo0(int sellIn, int quality)
        {
            var item = new Item { Name = "Elixir of the Mongoose", SellIn = sellIn, Quality = quality };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == 0);
        }
    }
}
