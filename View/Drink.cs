using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bartender
{
    [Table("drinks")]

    public class Drink
    {
        [Key]
        public string Name { get; set; }

        [Required]
        public virtual ICollection<Ingredient> Ingredient { get; set; }

    }
}
