using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackNDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> FoodSearch = new Dictionary<string, string>();

            FoodSearch.Add("Cheese", "12/05/26");
            FoodSearch.Add("Chocolate", "08/11/26");

            while (true)
            {
                Console.WriteLine("Welcome to Gorlock.AI");
                Console.WriteLine("1. Food expiry search");
                Console.WriteLine("2. Add food");
                Console.WriteLine("2. Update food");
                Console.WriteLine("3. Leftover");

                Console.Write("Input: ");
                int userinput = Convert.ToInt32(Console.ReadLine());

                switch (userinput)
                {
                    case 1:
                        Expiry(FoodSearch);
                        break;
                    case 2:
                        AddFood(FoodSearch);
                        break;
                    case 3:
                        UpdateFood(FoodSearch);
                        break;
                    case 4:
                        leftover();
                        break;
                 
                }

            }
        }
        static void Expiry(Dictionary<string, string> FoodSearch)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\n--- Current Fridge Inventory ---");
                foreach (var item in FoodSearch)
                {
                    Console.WriteLine($"Product: {item.Key}, Expiration: {item.Value}");
                }
                Console.WriteLine("---------------------------------------------------");
                Console.Write("Search bar (leave blank to go back): ");
                string searchKey = Console.ReadLine();

                if (searchKey.Equals(""))
                {
                    Console.Clear();
                    break;
                }

                if (FoodSearch.ContainsKey(searchKey))
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"{searchKey}'s expiry is {FoodSearch[searchKey]}");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.WriteLine($"{searchKey} not found in the fridge.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
        }
        static void AddFood(Dictionary<string, string> FoodSearch)
        {
            Console.Clear();
            Console.WriteLine("--- Add New Food ---");
            Console.Write("Enter food name: ");
            string name = Console.ReadLine();

            Console.Write("Enter expiration date (00/00/00): ");
            Console.Write("\nEnter Month (MM): ");
            string month = TwoDigit(12);

            Console.Write("\nEnter Day (DD): ");
            string day = TwoDigit(30);

            Console.Write("\nEnter Year (YY): ");
            string year = TwoDigit(99);

            string date = $"{month}/{day}/{year}";


            if (FoodSearch.ContainsKey(name))
            {
                Console.WriteLine($"{name} already exists! Use the Update option instead.");
            }
            else
            {
                FoodSearch.Add(name, date);
                Console.WriteLine($"{name} successfully added!");
            }

            Console.ReadKey();
            Console.Clear();
        }
        static string TwoDigit(int maxValue)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if ((input.Length == 1 || input.Length == 2) && int.TryParse(input, out int value))
                {
                    if (value >= 1 && value <= maxValue)
                    {
                        // If it's a single digit, return it with a 0 in front
                        if (input.Length == 1)
                        {
                            return $"0{input}";
                        }

                        return input;
                    }
                }

                Console.Write($"Invalid! Enter exactly 2 digits (1 to {maxValue}): ");
            }
        }
        static void UpdateFood(Dictionary<string, string> FoodSearch)
        {
            Console.Clear();
            Console.WriteLine("--- Update Existing Food ---");
            Console.Write("Enter food name to update: ");
            string name = Console.ReadLine();

            if (FoodSearch.ContainsKey(name))
            {
                Console.Write($"Enter new expiration date for {name} (Current: {FoodSearch[name]}): ");
                Console.Write("\nEnter expiration date (00/00/00): ");
                Console.Write("\nEnter Month (MM): ");
                string month = TwoDigit(12);

                Console.Write("\nEnter Day (DD): ");
                string day = TwoDigit(30);

                Console.Write("\nEnter Year (YY): ");
                string year = TwoDigit(99);

                string newDate = $"{month}/{day}/{year}";

                FoodSearch[name] = newDate;
                Console.WriteLine($"{name} updated successfully!");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"{name} is not in the fridge. Use Add option first.");
            }
        }
        static void leftover()
        {
            Stack<string> leftoverStack = new Stack<string>();

            leftoverStack.Push("Monday's Chili");
            leftoverStack.Push("Tuesday's Pasta");
            leftoverStack.Push("Wednesday's Stir-fry");

            Console.WriteLine($"Open fridge. The container on top is: {leftoverStack.Peek()}");

            string dinner = leftoverStack.Pop();
            Console.WriteLine($"You took and ate: {dinner}");

            Console.WriteLine($"The next container down is now: {leftoverStack.Peek()}");
        }
    }
}
