using AutoMapper;
using Project.BLL.DTOClasses.Abstracts;
using Project.BLL.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;
using Project.Entities.Interfaces;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class BaseManager<T,X> : IManager<T,X> where T : class, IEntity where X : class,IDTO
    {
        IMapper _mapper;
        IRepository<T> _iRep;
        public BaseManager(IRepository<T> iRep, IMapper mapper)
        {
            _iRep = iRep;
            _mapper = mapper;
        }
        public async Task AddAsync(X item)
        {
           await _iRep.AddAsync(_mapper.Map<T>(item));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
          return await _iRep.AnyAsync(exp);
        }

        public async Task  DeleteAsync(int id)
        {
           await _iRep.DeleteAsync(await _iRep.FindAsync(id));
        }

        public async Task<T> FindAsync(int id)
        {
            return await _iRep.FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.FirstOrDefaultAsync(exp);
        }

        public List<T> GetActives()
        {
           return _iRep.GetAll().Where(x =>x.Status != Entities.Enums.DataStatus.Inserted).ToList();
        }

        public List<T> GetAll()
        {
            return _iRep.GetAll();
        }

        public List<T> GetModifieds()
        {
            return _iRep.GetAll().Where(x => x.Status == Entities.Enums.DataStatus.Updated).ToList();
        }

        public List<T> GetPassives()
        {
            return _iRep.GetAll().Where(x => x.Status != Entities.Enums.DataStatus.Deleted).ToList();
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _iRep.Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _iRep.Select(exp);
        }

        public async Task UpdateAsync(X item)
        {
          await _iRep.UpdateAsync(_mapper.Map<T>(item));
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _iRep.Where(exp);
        }
    }
}
