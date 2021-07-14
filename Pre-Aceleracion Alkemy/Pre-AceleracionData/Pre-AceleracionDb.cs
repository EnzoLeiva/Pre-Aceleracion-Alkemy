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
        private const string Schema = "characters";
        public Pre_AceleracionDb(DbContextOptions<Pre_AceleracionDb> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
        }

        public DbSet<Movie> Movies { get; set; } = null;
        public DbSet<Gender> Genders { get; set; } = null;
        public DbSet<Character> Characters { get; set; } = null;
    }
}
