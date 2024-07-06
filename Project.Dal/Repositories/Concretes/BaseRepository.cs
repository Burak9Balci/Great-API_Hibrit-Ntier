using Microsoft.EntityFrameworkCore;
using Project.Dal.ContextClasses;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        MyContext _db;
        public BaseRepository(MyContext db)
        {
            _db = db;
        }
        public async Task AddAsync(T item)
        {
           await _db.Set<T>().AddAsync(item);
           await _db.SaveChangesAsync();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);
        }
        public async Task DeleteAsync(T item)
        {
            item.DeletedDate = DateTime.Now;
            item.Status = Entities.Enums.DataStatus.Deleted;
            await _db.SaveChangesAsync();
        }

        public async Task<T> FindAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(exp);
        }

        public List<T> GetAll()
        {
           return _db.Set<T>().ToList();
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public async Task UpdateAsync(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = Entities.Enums.DataStatus.Updated;
            T toBeUpdated = await FindAsync(item.ID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            await _db.SaveChangesAsync();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
           return _db.Set<T>().Where(exp).ToList();
        }
    }
}
