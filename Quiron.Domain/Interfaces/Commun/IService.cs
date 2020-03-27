using System;
using System.Linq;

namespace Quiron.Domain.Interfaces.Commun
{
    public interface IService<TModel>
    {
        void Create(TModel model);

        void Update(TModel model);

        void Remove(TModel model);

        IQueryable<TModel> GetAll();

        TModel FindById(Guid id);
    }
}