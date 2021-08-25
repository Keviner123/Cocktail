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


            public void GetAll()
            {
                using (var ctx = new DAL_DB())
                {
                    ctx.Drinks.
                }
            }

            public void FillDatabase()
            {


                using (var ctx = new DAL_DB())
                {
                var CokeAdd = new Drink();
                CokeAdd.Name = "AGoodDrink";
                CokeAdd.Ingredient = new List<Ingredient>() { 

                        //AI Ingredient ID
                        new Ingredient(ctx.Liquid.Find("Coke"), 250),
                        //new Ingredient(ctx.Liquid.Find("Rum"), 250),
                };


                ctx.Drinks.Add(CokeAdd);
                ctx.SaveChanges();
                }
        }
    }
}
