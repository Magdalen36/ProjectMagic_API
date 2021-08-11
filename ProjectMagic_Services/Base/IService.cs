using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMagic_Services.Base
{
    public interface IService<T>
        where T : class

    {
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity, int id);
    }
}
