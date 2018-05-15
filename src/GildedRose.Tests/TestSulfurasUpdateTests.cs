using GildedRose.Domain;
using Xunit;

namespace GildedRose.Tests
{
    public class TestSulfurasUpdateTests : TestBase
    {
        [Fact]
        public void TestSulfuras()
        {
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};

            UpdateQualityService.UpdateQuality(item);

            Assert.True(item.SellIn == 0);
            Assert.True(item.Quality == 80);
        }
    }
}