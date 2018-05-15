using GildedRose.Domain;
using Xunit;

namespace GildedRose.Tests
{
    public class TestDexterityUpdateTests: TestBase
    {
        [Theory]
        [InlineData(15, 7)]
        [InlineData(12, 10)]
        public void TestDexterity(int sellIn, int quality)
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality - 1);
        }

        [Theory]
        [InlineData(-3, 7)]
        [InlineData(-1, 10)]
        public void TestDexteritySellInLowerThan0(int sellIn, int quality)
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == quality - 2);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(1, 1)]
        public void TestDexterityQualityTo0(int sellIn, int quality)
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == sellIn - 1);
            Assert.True(item.Quality == 0);
        }
    }
}
