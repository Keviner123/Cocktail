using Bartender.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bartender
{

    class Program
    {
        static void Main(string[] args)
        {
            DAL_DB DBConnection = new DAL_DB();

            bool continuemenu = true;

            while (continuemenu)
            {

                Console.WriteLine("A: Add liquid U: List liquids C: Add drink Y: List drinks");

                string menu = Console.ReadLine();


                switch (menu)
                {
                    case "a":
                        Console.WriteLine("Enter a name for the new liquid");
                        string UserLiquidName = Console.ReadLine();
                        DBConnection.AddNewLiquid(UserLiquidName, 0);
                        break;

                    case "u":
                        Console.WriteLine(DBConnection.GetAllLiquids()); 
                        break;

                    case "c":
                        Console.WriteLine("Enter a name for the new drink");
                        string UserDrinkName = Console.ReadLine();
                        DBConnection.AddNewDrink(UserDrinkName); 
                        break;

                    case "y":
                        Console.WriteLine(DBConnection.GetAllDrinks());
                        break;

                    case "d":
                        Console.WriteLine("Add liquid to drink");
                        string UserDrinkChoice = Console.ReadLine();
                        string UserLiquidChoice = Console.ReadLine();
                        string UserLiquidAmount = Console.ReadLine();

                        DBConnection.AddLiquidToDrink(UserDrinkChoice, UserLiquidChoice, UserLiquidAmount);
                        break;

                    case "e":
                    default:
                        continuemenu = false;
                        break;
                }
            }

            DBConnection.GetAllLiquids();
            Console.ReadKey();


        }
    }
}
