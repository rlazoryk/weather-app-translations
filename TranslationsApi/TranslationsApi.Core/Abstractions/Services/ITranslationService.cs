using TranslationsApi.Core.DTO;

namespace TranslationsApi.Core.Abstractions.Services
{
    public interface ITranslationService: ICrudService<InLanguageDTO, OutLanguageDTO, int>
    {
        OutLanguageDTO GetByLangCode(string langCode);
    }
}
