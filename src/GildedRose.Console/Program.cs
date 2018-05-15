using System.Collections.Generic;
using GildedRose.Domain;
using GildedRose.Services;
using Unity;

namespace GildedRose.Console
{
    public class Program
    {
        private static IList<Item> _items = ItemRepository.Items;
        private static IUpdateQualityService _updateQualityService;

        public Program()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUpdateQualityService, UpdateQualityService>();

            _updateQualityService = container.Resolve<IUpdateQualityService>();
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            _updateQualityService.UpdateQuality(_items);

            System.Console.ReadKey();
        }       
    }
}
