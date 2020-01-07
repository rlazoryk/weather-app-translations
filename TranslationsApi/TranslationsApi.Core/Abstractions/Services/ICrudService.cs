using System.Collections.Generic;

namespace TranslationsApi.Core.Abstractions.Services
{
    public interface ICrudService<TInEntityDTO, TOutEntityDTO, TPrimary> where TInEntityDTO: class where TOutEntityDTO: class
    {
        List<TOutEntityDTO> GetAll();

        TOutEntityDTO GetByKey(TPrimary Id);

        TOutEntityDTO Insert(TInEntityDTO entity);

        TOutEntityDTO Update(TInEntityDTO entity);

        void Delete(TPrimary Id);
    }
}
