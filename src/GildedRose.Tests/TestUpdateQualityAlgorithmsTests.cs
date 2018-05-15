using GildedRose.Domain;
using GildedRose.Services;
using Xunit;

namespace GildedRose.Tests
{
    public class TestUpdateQualityAlgorithmsTests
    {
        [Fact]
        public void TestDefaultUpdateAlgorithm()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };

            UpdateQualityAlgorithms.DefaultUpdateQualityAlgorithm(item, 1);

            Assert.True(item.Quality == 19);
        }

        [Theory]
        [InlineData(-3, 7)]
        [InlineData(-1, 10)]
        public void TestDefaultUpdateAlgorithmSellInLowerThan0(int sellIn, int quality)
        {
            var item = new Item { Name = "Elixir of the Mongoose", SellIn = sellIn, Quality = quality };

            UpdateQualityAlgorithms.DefaultUpdateQualityAlgorithm(item, 1);

            Assert.True(item.Quality == quality - 2);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(1, 1)]
        public void TestDefaultUpdateAlgorithmQualityTo0(int sellIn, int quality)
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };

            UpdateQualityAlgorithms.DefaultUpdateQualityAlgorithm(item, 1);

            Assert.True(item.Quality == 0);
        }


        [Fact]
        public void TestBrieUpdateAlgorithm()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };

            UpdateQualityAlgorithms.BrieUpdateQualityAlgorithm(item);

            Assert.True(item.Quality == 1);
        }

        [Theory]
        [InlineData(15, 49)]
        [InlineData(20, 50)]
        public void TestBrieUpdateAlgorithmQualityTo50(int sellIn, int quality)
        {
            var item = new Item
            {
                Name = "Aged Brie",
                SellIn = sellIn,
                Quality = quality
            };

            UpdateQualityAlgorithms.BrieUpdateQualityAlgorithm(item);

            Assert.True(item.Quality == 50);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void TestConcertUpdateAlgorithmSellinLowerEqual5(int sellIn)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 };

            UpdateQualityAlgorithms.ConcertUpdateQualityAlgorithm(item);

            Assert.True(item.Quality == 23);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void TestConcertUpdateAlgorithmSellinLowerEqual10(int sellIn)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 };

            UpdateQualityAlgorithms.ConcertUpdateQualityAlgorithm(item);

            Assert.True(item.Quality == 22);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(20)]
        public void TestConcertUpdateAlgorithmSellinGreaterThan10(int sellIn)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 };

            UpdateQualityAlgorithms.ConcertUpdateQualityAlgorithm(item);

            Assert.True(item.Quality == 21);
        }

        [Theory]
        [InlineData(-3)]
        [InlineData(-1)]
        public void TestConcertUpdateAlgorithmSellinLowerThan0(int sellIn)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 };

            UpdateQualityAlgorithms.ConcertUpdateQualityAlgorithm(item);

            Assert.True(item.Quality == 0);
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

            UpdateQualityAlgorithms.ConcertUpdateQualityAlgorithm(item);

            Assert.True(item.Quality == 50);
        }
    }
}
