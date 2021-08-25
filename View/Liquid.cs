using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bartender
{
    [Table("liquids")]


    public class Liquid
    {
        [Key]

        public string Name { get; set; }
        public double AlcoholPercentage { get; set; } 

        public Liquid(string name, double alcoholpercentage)
        {
            this.Name = name;
            this.AlcoholPercentage = alcoholpercentage;
        }

        public Liquid()
        {

        }
    }
}
