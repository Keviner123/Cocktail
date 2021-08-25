using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bartender
{
    [Table("ingredients")]

    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }

        public Liquid Liquid { get; set; }

        public double VolumeML { get; set; }

        [Required]
        public virtual ICollection<Drink> Drinks { get; set; }

        public Ingredient(Liquid liquid, double volumeml)
        {
            this.Liquid = liquid;
            this.VolumeML = volumeml;
        }

    }
}
