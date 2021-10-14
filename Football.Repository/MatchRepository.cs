using FotbalAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Football.Repository
{
    public class MatchRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal FootballInfoContext _context;

        internal DbSet<TEntity> _dbSet;

        public MatchRepository(FootballInfoContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetbyId(int id)
        {
            var element = _dbSet.Find(id);
            return element;
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Delete(TEntity entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
