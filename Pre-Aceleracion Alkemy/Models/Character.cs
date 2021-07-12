using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Models
{
    public class Character
    {
        public int CharacterID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Story { get; set; }
        [Required]
        public ICollection<Movie> Movies { get; set; }
    }
}
