using System.Linq;

namespace TranslationsApi.Core.Abstractions
{
    public interface IRepository<TEntity, TPrimary> where TEntity: class
    {
        TEntity GetByKey(TPrimary Id);

        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TPrimary Id);
    }
}
