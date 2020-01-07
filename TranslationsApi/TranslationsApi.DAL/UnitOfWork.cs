using TranslationsApi.Core.Abstractions;
using TranslationsApi.DAL.Repositories;

namespace TranslationsApi.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private TranslationsApiContext Context;

        public UnitOfWork(TranslationsApiContext context)
        {
            Context = context;
        }

        private ILanguageRepository _languageRepository;

        public ILanguageRepository LanguageRepository
        {
            get
            {
                return _languageRepository ??= new LanguageRepository(Context);
            }
        }

        private IKeyRepository _keyRepository;

        public IKeyRepository KeyRepository
        {
            get
            {
                return _keyRepository ??= new KeyRepository(Context);
            }
        }

        public void Dispose()
        {
            if(Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
