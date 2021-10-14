using System.Collections.Generic;

namespace Football.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> GetAll();

        TEntity GetbyId(int id);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(TEntity entityToDelete);
        void Delete(int id);

        void Save();
    }
}
