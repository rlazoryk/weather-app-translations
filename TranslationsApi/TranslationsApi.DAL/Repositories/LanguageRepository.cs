using Microsoft.EntityFrameworkCore;
using System.Linq;
using TranslationsApi.Core.Abstractions;
using TranslationsApi.Core.Models;

namespace TranslationsApi.DAL.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        protected readonly TranslationsApiContext Context;

        public LanguageRepository(TranslationsApiContext context)
        {
            this.Context = context;
        }        
        
        public void Add(Language language)
        {
            Context.Set<Language>().Add(language);
        }

        public void Delete(int Id)
        {            
            var entity = GetByKey(Id);
            Context.Set<Language>().Remove(entity);
        }

        public IQueryable<Language> GetAll()
        {
            return Context.Set<Language>().AsQueryable();
        }

        public Language GetByKey(int Id)
        {
            return Context.Set<Language>().Find(Id);
        }

        public void Update(Language language)
        {
            Context.Entry(language).State = EntityState.Modified;
        }
    }
}
