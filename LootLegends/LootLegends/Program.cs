using LootLegends.Items;
using LootLegends.Items.Food;
using LootLegends.Items.Gems;
using LootLegends.Items.Potions;
using LootLegends.Models;

namespace LootLegends
{
        internal class Program
        {
            static Random random = new Random();

            static void Main(string[] args)
            {
                Player player = new Player("Hero");

                bool running = true;

                while (running)
                {
                    Console.WriteLine("\n=== RPG INVENTORY ===");
                    Console.WriteLine("1. Buy Loot Crate");
                    Console.WriteLine("2. Show Inventory");
                    Console.WriteLine("3. Use Consumables");
                    Console.WriteLine("4. Show Glowables");
                    Console.WriteLine("5. Show Player Stats");
                    Console.WriteLine("0. Exit");

                    Console.Write("Choice: ");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Item item = GenerateRandomItem();
                            Console.WriteLine($"You received: {item}");
                            player.AddItem(item);
                            break;

                        case "2":
                            player.ShowInventory();
                            break;

                        case "3":
                            player.UseConsumables();
                            break;

                        case "4":
                            player.ShowGlowables();
                            break;

                        case "5":
                            player.ShowStats();
                            break;

                        case "0":
                            running = false;
                            break;
                    }
                }
            }

            static Item GenerateRandomItem()
            {
                Rarity rarity = (Rarity)random.Next(0, 5);
                int type = random.Next(0, 3);

                switch (type)
                {
                    case 0:
                        int potionType = random.Next(0, 2);
                        return potionType switch
                        {
                            0 => new PotionOfHealing(rarity),
                            _ => new PotionOfFlying(rarity)
                        };

                    case 1:
                        int foodType = random.Next(0, 2);
                        return foodType switch
                        {
                            0 => new Apple(rarity),
                            _ => new Sweetroll(rarity)
                        };

                    default:
                        int gemType = random.Next(0, 2);
                        return gemType switch
                        {
                            0 => new Ruby(rarity),
                            _ => new Sapphire(rarity)
                        };
                }
            }
        }
    
}
