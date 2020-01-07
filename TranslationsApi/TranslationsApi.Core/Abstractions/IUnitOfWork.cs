using System;

namespace TranslationsApi.Core.Abstractions
{
    public interface IUnitOfWork: IDisposable
    {
        ILanguageRepository LanguageRepository { get; }

        IKeyRepository KeyRepository { get; }

        void SaveChanges();
    }
}
