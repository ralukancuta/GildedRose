using GildedRose.Domain;
using Xunit;

namespace GildedRose.Tests
{
    public class TestConcertUpdateTests : TestBase
    {
        [Theory]
        [InlineData(12, 10)]
        [InlineData(11, 5)]
        public void TestBackstageConcertSellInGreaterThan10(int sellIn, int quality)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality
            };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality + 1);
        }

        [Theory]
        [InlineData(10, 7)]
        [InlineData(9, 10)]
        [InlineData(8, 5)]
        [InlineData(7, 3)]
        [InlineData(6, 10)]
        public void TestBackstageConcertSellInLowerEqual10(int sellIn, int quality)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality
            };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality + 2);
        }

        [Theory]
        [InlineData(5, 7)]
        [InlineData(4, 10)]
        [InlineData(3, 5)]
        [InlineData(2, 3)]
        [InlineData(1, 10)]
        [InlineData(0, 8)]
        public void TestBackstageConcertSellInLowerEqual5(int sellIn, int quality)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality
            };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality + 3);
        }

        [Theory]
        [InlineData(1, 47)]
        [InlineData(4, 48)]
        [InlineData(2, 49)]
        [InlineData(3, 50)]
        [InlineData(7, 48)]
        [InlineData(9, 49)]
        [InlineData(10, 50)]
        [InlineData(15, 49)]
        [InlineData(20, 50)]
        public void TestBackstageConcertQualityTo50(int sellIn, int quality)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality
            };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == 50);
        }

        [Theory]
        [InlineData(-3)]
        [InlineData(-2)]
        [InlineData(-1)]
        public void TestBackstageConcertSellInLowerThan0(int sellIn)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 6 };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == 0);
        }
    }
}