using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface GenericRepository<T>
    {
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(int id);
        T Get(int id);
        List<T> GetAll(); 
    }
}
