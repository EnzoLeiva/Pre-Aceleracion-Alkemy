using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Qualification { get; set; }
        [Required]
        public ICollection<Character> Characters { get; set; }
    }
}
