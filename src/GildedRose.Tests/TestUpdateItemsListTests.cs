using System.Collections.Generic;
using GildedRose.Domain;
using Xunit;

namespace GildedRose.Tests
{
    public class TestUpdateItemsListTests: TestBase
    {
        private readonly IList<Item> _items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

        private readonly List<Item> _newItems = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
            new Item {Name = "Aged Brie", SellIn = 1, Quality = 1},
            new Item {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21},
            new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 4}
        };

        [Fact]
        public void TestUpdateItemsList()
        {           
            UpdateQualityService.UpdateQuality(_items);

            for (var i = 0; i < _items.Count; i++)
            {
                Assert.True(_items[i].Quality == _newItems[i].Quality);
                Assert.True(_items[i].SellIn == _newItems[i].SellIn);
            }
        }
    }
}