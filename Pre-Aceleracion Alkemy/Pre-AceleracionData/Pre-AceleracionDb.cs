using Microsoft.EntityFrameworkCore;
using Pre_Aceleracion_Alkemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Pre_AceleracionData
{
    public class Pre_AceleracionDb : DbContext
    {
        public Pre_AceleracionDb(DbContextOptions<Pre_AceleracionDb> options) : base (options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}
