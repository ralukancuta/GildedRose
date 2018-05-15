using GildedRose.Services;

namespace GildedRose.Tests
{
    public class TestBase
    {
        public static IUpdateQualityService UpdateQualityService;

        public TestBase()
        {
            UpdateQualityService = new UpdateQualityService();
        }
    }
}
