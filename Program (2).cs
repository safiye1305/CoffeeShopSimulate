using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2024510018_safiye_cennet_arslan.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capital =100; //first budget
            int day = 1; //first day of game
            int coffee_packages = 0; //number of coffee packets at the beginning
            int coffee_cups = 0; //number of cup of coffee at the beginning
            int croissants = 0; //number of croissant at the beginning
            int croissant_package = 0; //number of croissant package at the beginning
            int coffee_shots=0; //number of coffee shots at the beginning 
            int choice =0;
            int order =0; //number of order at the beginning
            while (true)
            {
                if (choice != 8)
                {
                    Console.WriteLine("The number of working days is " + day);
                    Console.WriteLine("MENU");
                    Console.WriteLine("   1. Buy coffee package(5Z)");
                    Console.WriteLine("   2. Brew coffee");
                    Console.WriteLine("   3. Sell cup(s) of coffee(2Z)");
                    Console.WriteLine("   4. Buy packages of Croissant(10Z)");
                    Console.WriteLine("   5. Open 1 packages of Croissant");
                    Console.WriteLine("   6. Sell Croissant(s)(3Z)");
                    Console.WriteLine("   7. End of the day>");
                    Console.WriteLine("   8. Quit Game");
                    Console.WriteLine("Please select the choices you want to apply: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("How many packages of coffee do you want to buy?: ");
                            int coffee_packages_to_buy = Convert.ToInt32(Console.ReadLine());
                            if (capital >= 5 * coffee_packages_to_buy)
                            {
                                capital = capital - 5 * coffee_packages_to_buy;
                                Console.WriteLine("You bought " + coffee_packages_to_buy + "coffee packages. ");
                                coffee_packages = coffee_packages + coffee_packages_to_buy;
                                if (coffee_packages > 0)
                                {
                                    coffee_shots = coffee_shots + 3 * coffee_packages;
                                    Console.WriteLine((coffee_packages) * 3 + "shots of coffee brewed. ");
                                }
                                Console.WriteLine("Your capital is now: " + capital + "Z");
                                order++;
                            }
                            else
                                Console.WriteLine("Insufficient funds. Please enter the number of coffee packages you would like to purchase again.");
                            break;
                        case 2:
                            if (coffee_shots > 0)
                            {
                                coffee_shots = coffee_shots - 1;
                                coffee_cups = coffee_cups + 5;
                                Console.WriteLine("You brewed a cup of coffee. The total number of coffee cups is: " + coffee_cups);
                            }
                            else
                                Console.WriteLine("No coffee shots. Please purchase at least one coffee pack.");
                            break;
                        case 3:
                            Console.WriteLine("Please enter the number of coffee cups you want to sell: ");
                            int coffee_cups_to_sell = Convert.ToInt32(Console.ReadLine());
                            if (coffee_cups >= coffee_cups_to_sell)
                            {
                                capital = capital + coffee_cups_to_sell * 2;
                                coffee_cups = coffee_cups - coffee_cups_to_sell;
                                Console.WriteLine("You sold " + coffee_cups_to_sell + " cups of coffee");
                                Console.WriteLine("Your capital is now:" + capital + "Z");
                                order++;
                            }
                            else
                                Console.WriteLine("You do not have enough coffee cups. Please enter again.");
                            break;
                        case 4:
                            Console.WriteLine("Please enter the number of croissant packages you would like to purchase.");
                            int croissant_package_to_buy = Convert.ToInt32(Console.ReadLine());
                            if (capital >= croissant_package_to_buy * 10)
                            {
                                capital = capital - croissant_package_to_buy * 10;
                                croissant_package = croissant_package + croissant_package_to_buy;
                                Console.WriteLine("You bought " + croissant_package_to_buy + " croissant packages. ");
                                Console.WriteLine("Your capital is now:" + capital + "Z");
                                order++;
                            }
                            else
                                Console.WriteLine("Insufficient funds. Please re-enter the quantity of croissant packages you wish to purchase.");
                            break;
                        case 5:
                            if (croissant_package > 0)
                            {
                                croissant_package = croissant_package - 1;
                                croissants = croissants + 5;
                                Console.WriteLine("You opened a package of croissants. The number of croissants is: " + croissants);
                            }
                            else
                                Console.WriteLine("There is no croissant package. Please buy at least one croissant package.");
                            break;
                        case 6:
                            Console.WriteLine("Enter the number of croissants you want to sell.");
                            int croissants_to_sell = Convert.ToInt32(Console.ReadLine());
                            if (croissants >= croissants_to_sell)
                            {
                                capital = capital + croissants_to_sell * 3;
                                croissants = croissants - croissants_to_sell;
                                Console.WriteLine("You sold " + croissants_to_sell + " croissants");
                                Console.WriteLine("Your capital is now: " + capital + "Z");
                                order++;
                            }
                            else
                                Console.WriteLine("Not enough croissants. Please re-enter the number of croissants you want to sell.");
                            break;
                        case 7:
                            if (order >= 3)
                            {
                                day++;
                                order = 0;
                                if (coffee_cups > 0)
                                {
                                    coffee_cups = 0;
                                    Console.WriteLine("Your unsold coffees have become stale. Your unsold coffees have been thrown away.");
                                }
                                if (day % 2 == 1 && croissants > 0)
                                {
                                    croissants = 0;
                                    Console.WriteLine("Your unsold croissants have gone bad. All unsold croissants have been thrown away.");
                                }
                                Console.WriteLine("Your current capital is " + capital + "Z");
                                Console.WriteLine("The remaining packages of coffee: " + coffee_packages);
                                Console.WriteLine("The remaining shots of coffee: " + coffee_shots);
                                Console.WriteLine("The remaining packages of croissant: " + croissant_package);
                                Console.WriteLine("The remaining croissants: " + croissants);
                            }
                            else
                                Console.WriteLine("You must place at least 3 orders before the day ends.");
                            break;
                        case 8:
                            Console.WriteLine("GAME OVER");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.Please try again. ");
                            break;
                    }
                    if (order >=6)
                    {
                        day++;
                        Console.WriteLine("Today is over.Day" + day + "is starting");
                        order = 0;
                        if (coffee_cups > 0)
                        {
                            coffee_cups = 0;
                            Console.WriteLine("Your unsold coffees have become stale. Your unsold coffees have been thrown away.");
                        }
                        if (day % 2 == 0 && croissants > 0)
                        {
                            croissants = 0;
                            Console.WriteLine("Your unsold croissants have gone bad. All unsold croissants have been thrown away.");
                        }

                        Console.WriteLine("Your current capital is " + capital + "Z");
                        Console.WriteLine("The number of working days is " + day);
                        Console.WriteLine("The remaining packages of coffee: " + coffee_packages);
                        Console.WriteLine("The remaining shots of coffee: " + coffee_shots);
                        Console.WriteLine("The remaining packages of croissant: " + croissant_package);
                        Console.WriteLine("The remaining croissants: " + croissants);
                    }
                }
                else
                {
                    Console.WriteLine("Your final capital is: " + capital + "Z");
                    Console.WriteLine("Leaving the coffee shop. Have a good day!");
                    break;
                    }
                }
            }
        }
    }

