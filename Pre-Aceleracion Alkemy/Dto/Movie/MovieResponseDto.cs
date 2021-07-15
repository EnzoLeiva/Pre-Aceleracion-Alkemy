using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Dto.Movie
{
    public class MovieResponseDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Qualification { get; set; }
        public int? GenderID { get; set; }
        public int? CharacterID { get; set; }
    }
}
