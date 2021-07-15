using System;
using System.Collections.Generic;
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
        public int GenderID { get; set; }
        public virtual Gender Gender { get; set; }
        public ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}
