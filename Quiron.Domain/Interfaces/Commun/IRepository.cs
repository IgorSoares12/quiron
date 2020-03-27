using System;
using System.Linq;
using System.Linq.Expressions;

namespace Quiron.Domain.Interfaces.Commun
{
    public interface IRepository<TModel>
    {
        void Create(TModel model);

        void Update(TModel model);

        void Remove(TModel model);

        IQueryable<TModel> GetAll();

        TModel FindBy(Expression<Func<TModel, bool>> predicate);

        IQueryable<TModel> FindAllBy(Expression<Func<TModel, bool>> predicate);
    }
}