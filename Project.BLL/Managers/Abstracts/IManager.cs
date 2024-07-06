﻿using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IManager<T> where T : IEntity
    {
        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetModifieds();
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        List<T> Where(Expression<Func<T, bool>> exp);
        List<T> GetAll();
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);
        Task<T> FindAsync(int id);
    }
}
