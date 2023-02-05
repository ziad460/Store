using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Interfaces
{
    public interface IBaseService<T> where T:class
    {
        List<T> GetAll();
        T GetByID (int? id);
        void Add(T model);
        void Update(T model, int id);
        void Delete(int id);
    }
}
