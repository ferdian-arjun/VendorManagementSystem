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
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public void Dispose()
        {
            _context.Dispose();
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
            try
            {
                _dbSet.Add(entity);
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Put(TEntity entity)
        {
            try
            {
                if (entity is IDateUpdate dateUpdate)
                {
                    dateUpdate.updated_at = DateTime.Now;
                }

                _context.Entry(entity).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int SoftDelete(TEntity entity)
        {
            try
            {
                if (entity is ISoftDeletable softDeletable)
                {
                    softDeletable.deleted_at = DateTime.Now;
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        public int HardDelete(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
           
        }

    }
}