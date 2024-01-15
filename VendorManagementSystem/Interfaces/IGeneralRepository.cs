using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorManagementSystem.Interfaces
{
    public interface IGeneralRepository<TEntity, TKey> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TKey key);
        int Post(TEntity entity);
        int Put(TEntity entity);
        int HardDelete(TEntity entity);
        int SoftDelete(TEntity entity);
    }
}
