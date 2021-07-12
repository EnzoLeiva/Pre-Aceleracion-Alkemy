using Pre_Aceleracion_Alkemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Repository
{
    interface IRepository<T>
    {
        Task<T> Add(T x);
        Task<int> Delete(int? id);
        Task<T> GetByID(int? id);
        Task Update(T x);
    }
}
