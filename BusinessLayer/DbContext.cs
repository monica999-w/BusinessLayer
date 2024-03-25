using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DbContext<T> where T : Entity
    {
        private List<T> _entities;
        public DbContext()
        {
          _entities = new List<T>();
        }
        public List<T> Entities => this._entities;
    }
}

