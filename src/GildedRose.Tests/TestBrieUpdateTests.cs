using GildedRose.Domain;
using Xunit;

namespace GildedRose.Tests
{
    public class TestBrieUpdateTests : TestBase
    {
        [Theory]
        [InlineData(4, 7)]
        [InlineData(12, 5)]
        public void TestAgedBrie(int sellIn, int quality)
        {
            var item = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality + 1);
        }

        [Theory]
        [InlineData(15, 49)]
        [InlineData(20, 50)]
        public void TestAgedBrieQualityTo50(int sellIn, int quality)
        {
            var item = new Item
            {
                Name = "Aged Brie", SellIn = sellIn, Quality = quality};

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == 50);
        }
    }
}