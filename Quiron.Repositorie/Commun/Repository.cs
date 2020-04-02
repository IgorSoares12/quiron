using Microsoft.EntityFrameworkCore;
using Quiron.Data.Context;
using Quiron.Domain.Entities;
using Quiron.Domain.Interfaces.Commun;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Quiron.Data.Commun
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : Entity
    {
        protected readonly QuironContext _context;

        public Repository(QuironContext context)
            => _context = context;

        public void Create(TModel model)
        {
            _context.Set<TModel>().Add(model);
            _context.SaveChanges();
        }

        public void Update(TModel model)
        {
            DetachLocal(model);
            _context.Set<TModel>().Update(model);
            _context.SaveChanges();
        }

        public void Remove(TModel model)
        {
            DetachLocal(model);
            _context.Set<TModel>().Remove(model);
            _context.SaveChanges();
        }

        public IQueryable<TModel> GetAll()
            => _context.Set<TModel>().AsQueryable();

        public TModel FindBy(Expression<Func<TModel, bool>> predicate)
            => _context.Set<TModel>().Where(predicate).FirstOrDefault();

        public TModel FindById(Guid id)
            => FindBy(t => t.Id.Equals(id));

        public IQueryable<TModel> FindAllBy(Expression<Func<TModel, bool>> predicate)
            => _context.Set<TModel>().Where(predicate).AsQueryable();

        private void DetachLocal(TModel model)
        {
            TModel local = _context.Set<TModel>().Local.Where(m => m.Id.Equals(model.Id)).FirstOrDefault();
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}