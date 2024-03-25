using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public interface IRepository<T> where T : Entity
    {
        int Save(T entity);
        T GetEntityById(int id);

    }
}
