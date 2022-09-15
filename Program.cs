using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannedMeat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.ShowAllCannedMeats();
            Console.WriteLine();
            storage.ShowExpiredCannedMeats();
        }
    }

    class Storage
    {
        private List<CannedMeat> _cannedMeats = new List<CannedMeat>();
        private int _thisYear = 2022;

        public Storage()
        {
            _cannedMeats.Add(new CannedMeat("Три поросёнка", 3, 2022));
            _cannedMeats.Add(new CannedMeat("Три поросёнка", 3, 2020));
            _cannedMeats.Add(new CannedMeat("Три поросёнка", 3, 2018));
            _cannedMeats.Add(new CannedMeat("Три поросёнка", 3, 2015));
            _cannedMeats.Add(new CannedMeat("Курочка Ряба", 2, 2022));
            _cannedMeats.Add(new CannedMeat("Курочка Ряба", 2, 2021));
            _cannedMeats.Add(new CannedMeat("Курочка Ряба", 2, 2020));
            _cannedMeats.Add(new CannedMeat("Курочка Ряба", 2, 2018));
            _cannedMeats.Add(new CannedMeat("Веселая корова", 4, 2022));
            _cannedMeats.Add(new CannedMeat("Веселая корова", 4, 2021));
            _cannedMeats.Add(new CannedMeat("Веселая корова", 4, 2018));
            _cannedMeats.Add(new CannedMeat("Веселая корова", 4, 2017));
        }
        public void ShowExpiredCannedMeats()
        {
            Console.WriteLine("Просроченные консервы: ");
            var expiredCannedMeats = _cannedMeats.Where(cannedMeat => _thisYear - cannedMeat.StorageLife >= cannedMeat.ProductionDate).ToList();
            ShowInfo(expiredCannedMeats);
        }


        public void ShowAllCannedMeats()
        {
            Console.WriteLine("Все консервы на складе:");
            ShowInfo(_cannedMeats);
        }

        private void ShowInfo(List<CannedMeat> cannedMeats)
        {
            foreach (var cannedMeat in cannedMeats)
            {
                Console.WriteLine($"Название тушенки: {cannedMeat.Name}. Срок хранения - {cannedMeat.StorageLife} года/лет. Год производства - {cannedMeat.ProductionDate}");
            }
        }
    }

    class CannedMeat
    {
        public string Name { get; private set; }
        public int StorageLife { get; private set; }
        public int ProductionDate  { get; private set; }

        public CannedMeat(string name, int storageLife, int productionDate)
        {
            Name = name;
            StorageLife = storageLife;
            ProductionDate = productionDate;
        }
    }
}
