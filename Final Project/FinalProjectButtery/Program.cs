using System;
using System.Collections.Generic;
using System.Linq;

/***************************************************************
* Name         : Final Project
* Author       : Heather Buttery
* Created      : 04/24/2023
* Course       : CIS 152 - Data Structures
* Version      : 1.0
* OS           : Windows 10
* IDE          : Visual Studio 2019
* Copyright    : This is my own original work based on
*                      specifications issued by our instructor
* Description  : Auto Inventory System
*                      Input :  Car Data
*                      Output: Results
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.        
***************************************************************/

namespace FinalProjectButtery
{
    public class Program
    {
        public static List<CarList> cars = new List<CarList>();
        static int stockNumber, year;
        static string make, model, color;
        static decimal mileage, price;

        public static void Main(string[] args)
        {
            string ch = "";
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("--------  AUTO INVENTORY SYSTEM  --------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();

            do
            {
                Console.WriteLine(" 1. Add a Car");
                Console.WriteLine(" 2. Update a Car");
                Console.WriteLine(" 3. Delete a Car");
                Console.WriteLine(" 4. Search for a Car");
                Console.WriteLine(" 5. View a Full List of Cars");
                Console.WriteLine(" 6. Exit");
                Console.WriteLine();
                Console.WriteLine("Select your choice : ");
                int choice = 0;
                bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out choice);


                switch (choice)
                {
                    case 1:
                        EnterStockNumber();
                        bool exists = cars.Exists(x => x.stockNumber == stockNumber);
                        if (exists)
                        {
                            Console.WriteLine("This stock number already exists");
                        }
                        else
                        {
                            Console.WriteLine("Please provide the details below");
                            Console.WriteLine("---------------------------------------");
                            EnterYear();
                            EnterMake();
                            EnterModel();
                            EnterColor();
                            EnterMileage();
                            EnterPrice();
                            cars.Add(new CarList(stockNumber, year, make, model, color, mileage, price));
                        }
                        break;

                    case 2:
                        UpdateCar(); break;

                    case 3:
                        DeleteCar(); break;

                    case 4:

                        Console.WriteLine("What would you like to search by?");
                        Console.WriteLine();
                        Console.WriteLine(" 1. By Stock Number");
                        Console.WriteLine(" 2. By Year");
                        Console.WriteLine(" 3. By Make");
                        Console.WriteLine(" 4. By Model");
                        Console.WriteLine(" 5. By Color");
                        Console.WriteLine();
                        Console.WriteLine("Select your choice : ");
                        int choicetwo = 0;
                        bool IsConversionSuccessfulTwo = int.TryParse(Console.ReadLine(), out choicetwo);

                        switch (choicetwo)
                        {
                            case 1:
                                EnterStockNumber();
                                SearchForCarStock(stockNumber); break;

                            case 2:
                                EnterYear();
                                SearchForCarYear(year);
                                break;
                            case 3:
                                EnterMake();
                                SearchForCarMake(make);
                                break;
                            case 4:
                                EnterModel();
                                SearchForCarModel(model);
                                break;
                            case 5:
                                EnterColor();
                                SearchForCarColor(color);
                                break;

                            default:
                                Console.WriteLine("Invalid Choice. Please enter a valid choice");
                                Console.WriteLine();
                                break;
                        }
                        break;
                    case 5:
                        ViewAllCars(); break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. Please enter a valid choice");
                        Console.WriteLine();
                        break;
                }

                do
                {
                    Console.WriteLine("Do you want to continue to the Application, Say (y or n)");
                    ch = Console.ReadLine().Trim().ToUpper();

                    if (ch != "Y" && ch != "N")
                    {
                        Console.WriteLine("Invalid Choice, Please say (y or n)");
                        Console.WriteLine();
                    }
                } while (ch != "Y" && ch != "N");

            } while (ch == "Y");

            Console.WriteLine("--- Program Terminated --- ");
        }





        public static void EnterStockNumber()
        {
            Console.WriteLine("Enter Stock Number : ");
            bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out stockNumber);

            if (!IsConversionSuccessful)
            {
                Console.WriteLine("Please enter a valid format");
                Console.WriteLine();
                EnterStockNumber();
            }
        }




        public static void EnterYear()
        {
            Console.WriteLine("Enter Year: ");
            bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out year);

            if (!IsConversionSuccessful)
            {
                Console.WriteLine("Please enter a valid format (YYYY)");
                Console.WriteLine();
                EnterYear();
            }
        }




        public static void EnterMake()
        {
            Console.WriteLine("Enter Make : ");
            make = Console.ReadLine().ToUpper();
        }




        public static void EnterModel()
        {
            Console.WriteLine("Enter Model : ");
            model = Console.ReadLine().ToUpper();
        }




        public static void EnterColor()
        {
            Console.WriteLine("Enter Color: ");
            color = Console.ReadLine().ToUpper();
        }




        public static void EnterMileage()
        {
            Console.WriteLine("Enter Mileage: ");
            bool IsConversionSuccessful = decimal.TryParse(Console.ReadLine(), out mileage);

            if (!IsConversionSuccessful)
            {
                Console.WriteLine("Please enter a valid format (9999.99)");
                Console.WriteLine();
                EnterMileage();
            }
        }




        public static void EnterPrice()
        {
            Console.WriteLine("Enter Price: ");
            bool IsConversionSuccessful = decimal.TryParse(Console.ReadLine(), out price);

            if (!IsConversionSuccessful)
            {
                Console.WriteLine("Please enter a valid format (9999.99)");
                Console.WriteLine();
                EnterPrice();
            }
        }




        public static void UpdateCar()
        {
            EnterStockNumber();
            CarList car = cars.Find(x => x.stockNumber == stockNumber);

            if (car is null)
            {
                Console.WriteLine("No matchng inventory found...");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"{"STOCKNUM",15}" + $"{"YEAR",15}" + $"{"MAKE",15}" + $"{"MODEL",15}" + $"{"COLOR",15}" + $"{"MILEAGE",15}" + $"{"PRICE",15}");
                Console.WriteLine("------------------------");
                Console.WriteLine($"{car.stockNumber,15}" + $"{car.year,15}" + $"{car.make,15}" + $"{car.model,15}" + $"{car.color,15}" + $"{car.mileage,15}" + $"{"$" + car.price,15}");

                Console.WriteLine("Is this the car you want to update? y or n");
                string ch = Console.ReadLine().Trim().ToUpper();
                if (ch != "Y" && ch != "N")
                {
                    Console.WriteLine("Invalid Choice, Please say (y or n)");
                    UpdateCar();
                }
                else if (ch == "Y")
                {
                    Console.WriteLine("1. Update Stock Number");
                    Console.WriteLine("2. Update Year");
                    Console.WriteLine("3. Update Make");
                    Console.WriteLine("4. Update Model");
                    Console.WriteLine("5. Update Color");
                    Console.WriteLine("6. Update Mileage");
                    Console.WriteLine("7. Update Price");

                    do
                    {
                        Console.WriteLine("Select the option you want to update : ");
                        int choice = 0;
                        bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out choice);

                        if (!IsConversionSuccessful)
                        {
                            Console.WriteLine("Please enter a valid format");
                            Console.WriteLine();
                        }
                        else
                        {

                            switch (choice)
                            {
                                case 1:
                                    EnterStockNumber();
                                    if (stockNumber != 0)
                                    {
                                        bool exists = cars.Exists(x => x.stockNumber == stockNumber);
                                        if (exists)
                                        {
                                            Console.WriteLine("Stock Number already exists");
                                            Console.WriteLine();
                                        }
                                        else
                                        {
                                            car.stockNumber = stockNumber;
                                        }
                                    }
                                    break;

                                case 2:
                                    EnterYear();
                                    car.year = year; break;
                                case 3:
                                    EnterMake();
                                    car.make = make; break;

                                case 4:
                                    EnterModel();
                                    car.model = model; break;

                                case 5:
                                    EnterColor();
                                    car.color = color; break;

                                case 6:
                                    EnterMileage();
                                    car.mileage = mileage; break;

                                case 7:
                                    EnterPrice();
                                    car.price = price; break;

                                default:
                                    Console.WriteLine("Invalid Choice"); break;
                            }

                            do
                            {
                                Console.WriteLine("Is there anything else you want to update on this specific car?, Say (y or n)");
                                ch = Console.ReadLine().Trim().ToUpper();

                                if (ch != "Y" && ch != "N")
                                {
                                    Console.WriteLine("Invalid Choice, Please say (y or n)");
                                }
                            } while (ch != "Y" && ch != "N");
                        }
                    } while (ch == "Y");
                }
                else
                {
                    Console.WriteLine("Please reenter the stock number.");
                    UpdateCar();
                }
            }
        }







        public static void DeleteCar()
        {
            EnterStockNumber();
            CarList car = cars.Find(x => x.stockNumber == stockNumber);
            if (car is null)
            {
                Console.WriteLine("This stock number does not exist...");
                Console.WriteLine();
                DeleteCar();
            }
            else
            {
                Console.WriteLine($"{car.stockNumber,15}" + $"{car.year,15}" + $"{car.make,15}" + $"{car.model,15}" + $"{car.color,15}" + $"{car.mileage,15}" + $"{"$" + car.price,15}");

                Console.WriteLine("Is this the car you want to delete? y or n");
                string ch = Console.ReadLine().Trim().ToUpper();
                if (ch != "Y" && ch != "N")
                {
                    Console.WriteLine("Invalid Choice, Please say (y or n)");
                    DeleteCar();
                }
                else if (ch == "Y")
                {
                    bool res = cars.Remove(car);

                    if (res)
                    {
                        Console.WriteLine($"Stock number {car.stockNumber} removed successfully !!");
                    }
                    else
                    {
                        Console.WriteLine("No matching inventory found...");
                    }
                }
                else
                {
                    Console.WriteLine("Please reenter the stock number.");
                    DeleteCar();
                }
            }
        }





        public static void SearchForCarStock(int stockNumber)
        {
            var match = cars.Where(x => x.stockNumber == stockNumber);

            Console.WriteLine($"{"COUNT",15}" + $"{"STOCKNUM",15}" + $"{"YEAR",15}" + $"{"MAKE",15}" + $"{"MODEL",15}" + $"{"COLOR",15}" + $"{"MILEAGE",15}" + $"{"PRICE",15}");
            Console.WriteLine("------------------------");
            int counter = 0;
            foreach (var i in match.OrderBy(p => p.year))
            {
                Console.WriteLine($"{counter++ + 1,15}" + $"{i.stockNumber,15}" + $"{i.year,15}" + $"{i.make,15}" + $"{i.model,15}" + $"{i.color,15}" + $"{i.mileage,15}" + $"{"$" + i.price,15}");
            }
            if (counter == 0)
            {
                Console.WriteLine("No matchng inventory found...");
            }
        }





        public static void SearchForCarYear(int year)
        {
            var match = cars.Where(x => x.year == year);

            Console.WriteLine($"{"COUNT",15}" + $"{"STOCKNUM",15}" + $"{"YEAR",15}" + $"{"MAKE",15}" + $"{"MODEL",15}" + $"{"COLOR",15}" + $"{"MILEAGE",15}" + $"{"PRICE",15}");
            Console.WriteLine("------------------------");
            int counter = 0;
            foreach (var i in match.OrderBy(p => p.year))
            {
                Console.WriteLine($"{counter++ + 1,15}" + $"{i.stockNumber,15}" + $"{i.year,15}" + $"{i.make,15}" + $"{i.model,15}" + $"{i.color,15}" + $"{i.mileage,15}" + $"{"$" + i.price,15}");
            }
            if (counter == 0)
            {
                Console.WriteLine("No matchng inventory found...");
            }
        }






        public static void SearchForCarMake(string make)
        {
            var match = cars.Where(x => x.make == make);

            Console.WriteLine($"{"COUNT",15}" + $"{"STOCKNUM",15}" + $"{"YEAR",15}" + $"{"MAKE",15}" + $"{"MODEL",15}" + $"{"COLOR",15}" + $"{"MILEAGE",15}" + $"{"PRICE",15}");
            Console.WriteLine("------------------------");
            int counter = 0;
            foreach (var i in match.OrderBy(p => p.year))
            {
                Console.WriteLine($"{counter++ + 1,15}" + $"{i.stockNumber,15}" + $"{i.year,15}" + $"{i.make,15}" + $"{i.model,15}" + $"{i.color,15}" + $"{i.mileage,15}" + $"{"$" + i.price,15}");
            }
            if (counter == 0)
            {
                Console.WriteLine("No matchng inventory found...");
            }
        }






        public static void SearchForCarModel(string model)
        {
            var match = cars.Where(x => x.model == model);


            Console.WriteLine($"{"COUNT",15}" + $"{"STOCKNUM",15}" + $"{"YEAR",15}" + $"{"MAKE",15}" + $"{"MODEL",15}" + $"{"COLOR",15}" + $"{"MILEAGE",15}" + $"{"PRICE",15}");
            Console.WriteLine("------------------------");
            int counter = 0;
            foreach (var i in match.OrderBy(p => p.year))
            {
                Console.WriteLine($"{counter++ + 1,15}" + $"{i.stockNumber,15}" + $"{i.year,15}" + $"{i.make,15}" + $"{i.model,15}" + $"{i.color,15}" + $"{i.mileage,15}" + $"{"$" + i.price,15}");
            }
            if (counter == 0)
            {
                Console.WriteLine("No matchng inventory found...");
            }
        }





        public static void SearchForCarColor(string color)
        {
            var match = cars.Where(x => x.color == color);

            Console.WriteLine($"{"COUNT",15}" + $"{"STOCKNUM",15}" + $"{"YEAR",15}" + $"{"MAKE",15}" + $"{"MODEL",15}" + $"{"COLOR",15}" + $"{"MILEAGE",15}" + $"{"PRICE",15}");
            Console.WriteLine("------------------------");
            int counter = 0;
            foreach (var i in match.OrderBy(p => p.year))
            {
                Console.WriteLine($"{counter++ + 1,15}" + $"{i.stockNumber,15}" + $"{i.year,15}" + $"{i.make,15}" + $"{i.model,15}" + $"{i.color,15}" + $"{i.mileage,15}" + $"{"$" + i.price,15}");
            }
            if (counter == 0)
            {
                Console.WriteLine("No matchng inventory found...");
            }
        }





        public static void ViewAllCars()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("There are no cars listed.");
            }
            else
            {
                Console.WriteLine($"{"COUNT",15}" + $"{"STOCKNUM",15}" + $"{"YEAR",15}" + $"{"MAKE",15}" + $"{"MODEL",15}" + $"{"COLOR",15}" + $"{"MILEAGE",15}" + $"{"PRICE",15}");
                Console.WriteLine("------------------------");
                int counter = 0;
                foreach (CarList car in cars.OrderBy(p => p.year))
                {
                    Console.WriteLine($"{counter++ + 1,15}" + $"{car.stockNumber,15}" + $"{car.year,15}" + $"{car.make,15}" + $"{car.model,15}" + $"{car.color,15}" + $"{car.mileage,15}" + $"{"$" + car.price,15}");
                }
            }
        }
    }
}