using BusinessLayer.Entities;


namespace BusinessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {

        private readonly DbContext<T> _context;

        public Repository(DbContext<T> context)
        {
            _context = context;
        }

        public T GetEntityById(int id)
        {
            return _context.Entities.FirstOrDefault(entity => entity.Id == id);
        }

        public int Save(T entity)
        {
            
            if (entity.Id == 0)
            {
                
                entity.Id = _context.Entities.Count + 1;
                _context.Entities.Add(entity);
            }
            else
            {
               
                var existingEntity = _context.Entities.FirstOrDefault(e => e.Id == entity.Id);
                if (existingEntity != null)
                {
                    existingEntity = entity;
                }
            }
           
            return entity.Id;
        }
    }
    
}
