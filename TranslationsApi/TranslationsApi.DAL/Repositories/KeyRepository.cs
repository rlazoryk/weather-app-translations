using Microsoft.EntityFrameworkCore;
using System.Linq;
using TranslationsApi.Core.Abstractions;
using TranslationsApi.Core.Models;

namespace TranslationsApi.DAL.Repositories
{
    public class KeyRepository: IKeyRepository
    {
        protected readonly TranslationsApiContext Context;
         
        public KeyRepository(TranslationsApiContext context)
        {
            this.Context = context;
        }

        public void Add(Key key)
        {
            Context.Set<Key>().Add(key);
        }

        public void Delete(object[] key)
        {
            var entity = GetByKey(key);
            Context.Set<Key>().Remove(entity);
        }

        public IQueryable<Key> GetAll()
        {
            return Context.Set<Key>().AsQueryable();
        }

        public Key GetByKey(object[] key)
        {
            return Context.Set<Key>().Find(key[0], key[1]);
        }

        public void Update(Key key)
        {           
            Context.Entry(key).State = EntityState.Modified;
        }
    }
}
