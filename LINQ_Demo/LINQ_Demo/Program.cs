using LINQ_Demo.Models;
using System.Runtime.InteropServices;
using System.Text;

namespace LINQ_Demo
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var orchestra = new Store { Name = "Orchestra Pianos", Address = "Thonissenlaan 34, 3500 Hasselt" };
            var gert = new Store { Name = "Gert Schrijvers", Address = "Guido Gezellestraat 8, 3500 Hasselt" };
            var vdm = new Store { Name = "Van de Moer Instruments", Address = "Maastrichterstraat 107, 3500 Hasselt" };

            var inventory = new List<Instrument> {
            // Orchestra piano stock
            new Piano { Id = 1, Brand = "Steinway", Price = 45000, Condition = "New", IsGrand = true, Shop = orchestra },
            new Piano { Id = 2, Brand = "Yamaha", Price = 8500, Condition = "Used", IsGrand = false, Shop = orchestra },
            new Piano { Id = 3, Brand = "Bösendorfer", Price = 62000, Condition = "New", IsGrand = true, Shop = orchestra },
            new Piano { Id = 4, Brand = "Kawai", Price = 4200, Condition = "Used", IsGrand = false, Shop = orchestra },
            new Piano { Id = 5, Brand = "Casio", Price = 1200, Condition = "New", IsGrand = false, Shop = orchestra },

            // Van de Moer guitaar en viool stock
            new Guitar { Id = 6, Brand = "Fender", Price = 1200, Condition = "Used", StringCount = 6, Shop = vdm },
            new Guitar { Id = 7, Brand = "Gibson", Price = 2500, Condition = "New", StringCount = 6, Shop = vdm },
            new Guitar { Id = 8, Brand = "Ibanez", Price = 950, Condition = "New", StringCount = 7, Shop = vdm },
            new Guitar { Id = 9, Brand = "Taylor", Price = 3200, Condition = "New", StringCount = 6, Shop = vdm },
            new Guitar { Id = 10, Brand = "Martin", Price = 1800, Condition = "Used", StringCount = 6, Shop = vdm },
            new Guitar { Id = 11, Brand = "Epiphone", Price = 450, Condition = "Used", StringCount = 6, Shop = vdm },
            new Guitar { Id = 12, Brand = "Gretsch", Price = 2100, Condition = "New", StringCount = 6, Shop = vdm },
            new Violin { Id = 13, Brand = "Strunal", Price = 800, Condition = "New", Size = "4/4", Shop = vdm },
            new Violin { Id = 14, Brand = "Strunal", Price = 700, Condition = "New", Size = "3/4", Shop = vdm },

            // Gert Schrijvers viool stock
            new Violin { Id = 15, Brand = "Schrijvers Custom", Price = 3500, Condition = "New", Size = "4/4", Shop = gert },
            new Violin { Id = 16, Brand = "Stradivarius Copy", Price = 1500, Condition = "Used", Size = "4/4", Shop = gert },
            new Violin { Id = 17, Brand = "Yamaha Silent", Price = 1100, Condition = "New", Size = "4/4", Shop = gert },
            new Violin { Id = 18, Brand = "Hoffmann", Price = 850, Condition = "Used", Size = "3/4", Shop = gert },
            new Violin { Id = 19, Brand = "Strunal", Price = 600, Condition = "New", Size = "1/2", Shop = gert },
            new Violin { Id = 20, Brand = "Paesold", Price = 2200, Condition = "New", Size = "4/4", Shop = gert }
        };

            // TODO: Schrijf hier je LINQ queries

            //1
            //foreach(var item in inventory.Where(i => i.Price < 2000))
            //{
            //    Console.WriteLine($"{item.Brand} - {item.Price}");
            //}

            //2
            //foreach (var item in inventory.Where(i => i.GetType() == typeof(Guitar)))
            //{
            //    Console.WriteLine($"{item.Brand} - {((Guitar)item).StringCount}");
            //}


            //3
            //foreach (var item in inventory.Where(i => i.Shop == vdm))
            //{
            //    Console.WriteLine(item.Brand);
            //}


            //4
            //foreach (var group in inventory.GroupBy(i => i.Shop))
            //{
            //    Console.WriteLine($"{group.Key.Name} - {group.Count()}");
            //}

            //5
            //foreach (var item in inventory.Where(i => i.GetType() == typeof(Violin) && i.Condition == "New").OrderBy(i => i.Brand))
            //{
            //    Console.WriteLine(item.Brand);
            //}

            //6
            //Instrument instrument = inventory.OrderByDescending(i => i.Price).FirstOrDefault();
            //Console.WriteLine($"Het duurste instrument is een {instrument.Brand} bij {instrument.Shop.Name}, gelegen op {instrument.Shop.Address}");

            //7
            //foreach( var item in inventory.GroupBy(i => i.GetType()))
            //{
            //    Console.WriteLine($"- {item.Key.Name}: average price = {item.Average(i => i.Price)}");
            //}

            //8
            //var joinedBeforeWhere = inventory.Join(
            //    inventory,
            //    inst => inst.Brand,
            //    inst2 => inst2.Brand,
            //    (inst, inst2) => new
            //    {
            //        inst.Condition,
            //        BrandNew = inst.Brand,
            //        ConditionOld = inst2.Condition,
            //        BrandSecondHand = inst2.Brand,
            //        inst2.Price
            //    });

            //var joined = joinedBeforeWhere.Where(i => i.Condition == "New" && i.ConditionOld == "Used");

            //foreach (var item in joined)
            //{
            //    Console.WriteLine($"Bij aankoop van een nieuwe {item.BrandNew}, bekijk ook deze occasie: {item.BrandSecondHand} voor maar {item.Price * 0.3}!");
            //}

            //8
            //var result = inventory.Where(i => i.Condition == "Used").GroupBy(i => i.Shop).OrderByDescending(i => i.Sum(i => i.Price)).FirstOrDefault();
            //Console.WriteLine(result.Key.Name + "heeft de meeste 2de hands insturmenten waarden: " + result.Sum(i => i.Price));

            var sales = new List<Sale> {
                new Sale { InstrumentId = 1, CustomerName = "Jean-Pierre", SoldAt = DateTime.Now.AddMonths(-1) },
                new Sale { InstrumentId = 15, CustomerName = "Marie", SoldAt = DateTime.Now.AddDays(-5) },
                new Sale { InstrumentId = 6, CustomerName = "Luc", SoldAt = DateTime.Now.AddDays(-2) },
                new Sale { InstrumentId = 3, CustomerName = "Sophie", SoldAt = DateTime.Now.AddMonths(-3) },
                new Sale { InstrumentId = 10, CustomerName = "Tom", SoldAt = DateTime.Now.AddDays(-10) },
                new Sale { InstrumentId = 12, CustomerName = "Emma", SoldAt = DateTime.Now.AddDays(-1) },
                new Sale { InstrumentId = 20, CustomerName = "Lucas", SoldAt = DateTime.Now.AddMonths(-2) }
            };

            //10
            //    var joined = inventory.Join(
            //        sales,
            //        instrument => instrument.Id,
            //        sale => sale.InstrumentId,
            //        (instrument, sale) => new
            //        {
            //            Naam = sale.CustomerName,
            //            Merk = instrument.Brand,
            //            Prijs = instrument.Price
            //        });

            //    foreach (var item in joined)
            //    {
            //        Console.WriteLine($"{item.Naam} kocht een {item.Merk} voor {item.Prijs}");
            //    }

            //11
            //var joined = inventory.Join(
            //    sales,
            //    inst => inst.Id,
            //    sale => sale.InstrumentId,
            //    (inst, sale) => new
            //    {
            //        inst.Shop,
            //        inst.Price
            //    }).GroupBy(i => i.Shop);

            //foreach (var item in joined)
            //{
            //    Console.WriteLine($"{item.Key.Name} heeft aan {item.Sum(i => i.Price)} euro verkocht");
            //}

            //12
            //var joined = inventory.GroupJoin(
            //    sales,
            //    inst => inst.Id,
            //    sale => sale.InstrumentId,
            //    (inst, sale) => new
            //    {
            //        inst.Brand,
                    
            //    });

            //foreach (var item in joined)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(joined.Count());
        }
    }
}
