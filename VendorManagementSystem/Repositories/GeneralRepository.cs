using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using VendorManagementSystem.Interfaces;

namespace VendorManagementSystem.Repositories
{
    public class GeneralRepository<TEntity, TKey> : IGeneralRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GeneralRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Get(TKey key)
        {
            return _dbSet.Find(key);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList().Where(entity => !(entity is ISoftDeletable) ||
               !((ISoftDeletable)entity).deleted_at.HasValue);
        }

        public int Post(TEntity entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }

        public int Put(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int SoftDelete(TEntity entity)
        {
            if (entity is ISoftDeletable softDeletable)
            {
                softDeletable.deleted_at = DateTime.Now;
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return _context.SaveChanges();
        }

        public int HardDelete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges();
        }
    }
}