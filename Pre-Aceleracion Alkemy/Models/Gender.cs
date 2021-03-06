using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Models
{
    public class Gender
    {
        public int GenderID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
