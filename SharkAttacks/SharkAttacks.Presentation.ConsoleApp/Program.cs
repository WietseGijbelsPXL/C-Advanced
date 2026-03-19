using SharkAttacks.Application;
using System.Drawing;

namespace SharkAttacks.Presentation.ConsoleApp
{
    internal class Program
    {
        static SharkAttacksService _service = new SharkAttacksService();

        static void Main(string[] args)
        {

            ShowOptions();
        }

        static void ShowOptions()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== Shark Attack Analyzer ===");
            Console.ResetColor();
            Console.WriteLine("1. View fatality rates");
            Console.WriteLine("2. View annual attack statistics");
            Console.WriteLine("3. Sort by most attacked activities");
            Console.WriteLine("4. Show attacks by country");
            Console.WriteLine("5. View most attacked body parts");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            switch (Console.ReadLine())
            {
                case "1":
                    ViewFatalityRates();
                    break;
                case "2":
                    AttacksByYear();
                    break;
                case "3":
                    AttacksByActivity();
                    break;

            }
        }

        static void ViewFatalityRates()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            GetTotalAttacks();
            GetFatalityRate();
        }

        static void GetFatalityRate()
        {
            float fatalityrate = (float)_service.GetFatalAttacks() / _service.GetTotalAttacks();
            Console.WriteLine($"Overall fatality rate: {fatalityrate}%");
        }

        static void GetTotalAttacks()
        {
            Console.WriteLine($"Total recorded attacks: {_service.GetTotalAttacks()}");
        }

        static void AttacksByYear()
        {
            foreach (var item in _service.GetAttacksByYear())
            {
                Console.ResetColor();
                Console.Write(item.Key + ": ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('\u2588', item.Value));
            }
        }

        static void AttacksByActivity()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Dangerous activities");
            foreach (var item in _service.GetAttacksByActivity())
            {
                Console.ResetColor();
                Console.Write(item.Key);
                for (int i = 20 - item.Key.Length; i >= 0; i--)
                {
                    Console.Write(" ");
                }
                Console.Write(":");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"({item.Value})");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(' ');
                Console.WriteLine(new string('\u2588', item.Value));
            }
        }
    }
}
