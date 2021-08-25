using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bartender.DAL
{
    public class DAL_DB: DbContext
        {
            public DAL_DB() : base(@"Server=localhost\SQLEXPRESS;Database=Bartender;Trusted_Connection=True;")
            {

            }

            public DbSet<Drink> Drinks { get; set; }
            public DbSet<Ingredient> Ingredient { get; set; }
            public DbSet<Liquid> Liquid { get; set; }


            public void AddNewLiquid(string liquidname, double alcoholpercentage)
            {
                using (var ctx = new DAL_DB())
                {
                    ctx.Liquid.Add(new Liquid() { Name = liquidname, AlcoholPercentage = alcoholpercentage });
                    ctx.SaveChanges();

                }
         }

        public void AddNewDrink(string drinkname)
        {
            using (var ctx = new DAL_DB())
            {
                ctx.Drinks.Add(new Drink() { Name = drinkname });
                ctx.SaveChanges();
            }
        }

        public void AddLiquidToDrink(string drinkname, string ingredientid, int amount)
        {
            using (var ctx = new DAL_DB())
            {
                var CokeAdd = ctx.Drinks.Find(drinkname);
                CokeAdd.Ingredient = new List<Ingredient>() { 

                        new Ingredient(ctx.Liquid.Find(ingredientid), amount),
                };

                ctx.Drinks.Add(CokeAdd);
                ctx.SaveChanges();
            }
        }

        public string GetAllLiquids()
            {
                string finalstring = "";
                using (var ctx = new DAL_DB())
                {
                    foreach (var liquid in ctx.Liquid)
                    {
                        finalstring += liquid.Name+"\n";
                    }
                }
            return(finalstring);
            }


        public string GetAllDrinks()
        {
            string finalstring = "";
            using (var ctx = new DAL_DB())
            {
                foreach (var drink in ctx.Drinks)
                {
                    finalstring += drink.Name+ "(";

                    if(drink.Ingredient != null)
                    {
                        foreach (var ingredient in drink.Ingredient)
                        {
                            finalstring += ingredient + "-";
                        }
                    }

                    finalstring += ")\n";
                }
            }
            return (finalstring);
        }
    }
}
