using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contratos
{
    public interface IBaseRepository<Obj> : IDisposable where Obj : class
    {
        void Insert(Obj objeto);
        void Remove(int id);
        IEnumerable<Obj> FindAll();
        Obj FindById(int id);
    }
}
