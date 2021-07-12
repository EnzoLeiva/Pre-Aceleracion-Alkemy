using Microsoft.EntityFrameworkCore;
using Pre_Aceleracion_Alkemy.Models;
using Pre_Aceleracion_Alkemy.Pre_AceleracionData;
using Pre_Aceleracion_Alkemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Repositorio
{
    public class RepositoryPersonaje : IRepository<Character>
    {
        Pre_AceleracionDb _db;
        public RepositoryPersonaje(Pre_AceleracionDb db)
        {
            _db = db;
        }
        public async Task<Character> Add(Character icono)
        {
            if (_db != null)
            {
                var obj = await _db.Characters.AddAsync(icono);
                _db.SaveChanges();
                return obj.Entity;
            }
            return null;
        }

        public async Task<int> Delete(int? id)
        {
            int result = 0;
            if (_db != null)
            {
                var icono = await _db.Characters.FirstOrDefaultAsync(x => x.CharacterID == id);
                _db.Characters.Remove(icono);
                result = await _db.SaveChangesAsync();
                return result;
            }     
            return result;
        }

        public async Task<Character> GetByID(int? id)
        {
            var personaje = await _db.Characters.FirstOrDefaultAsync(x => x.CharacterID == id);
            return personaje;
        }

        public async Task Update(Character p)
        {
            if (_db != null)
            {
                _db.Characters.Update(p);
                await _db.SaveChangesAsync();
            }
        }
    }
}
