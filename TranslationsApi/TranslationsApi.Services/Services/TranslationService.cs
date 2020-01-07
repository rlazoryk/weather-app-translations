using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TranslationsApi.Core.Abstractions;
using TranslationsApi.Core.Abstractions.Services;
using TranslationsApi.Core.DTO;
using TranslationsApi.Core.Models;

namespace TranslationsApi.Services.Services
{
    public class TranslationService : ITranslationService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TranslationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Delete(int Id)
        {
            var keys = _unitOfWork.KeyRepository.GetAll().Where(k => k.LanguageId == Id).ToList();
            keys.ForEach(k => _unitOfWork.KeyRepository.Delete(new object[] { k.LanguageId, k.KeyName }));

            _unitOfWork.LanguageRepository.Delete(Id);
            _unitOfWork.SaveChanges();
        }

        public List<OutLanguageDTO> GetAll()
        {
            var languages = _unitOfWork.LanguageRepository.GetAll().ToList();
            foreach (var lan in languages)
            {
                lan.Keys = _unitOfWork.KeyRepository.GetAll().Where(k => k.LanguageId == lan.Id).ToList();
            }
            var result = languages.Select(lang => _mapper.Map<OutLanguageDTO>(lang)).ToList();            
            return result;          
        }

        public OutLanguageDTO GetByKey(int Id)
        {
            var lang = _unitOfWork.LanguageRepository.GetByKey(Id);
            lang.Keys = _unitOfWork.KeyRepository.GetAll().Where(k => k.LanguageId == Id).ToList();
            var result = _mapper.Map<OutLanguageDTO>(lang);
            return result;
        }

        public OutLanguageDTO GetByLangCode(string langCode)
        {           
            var Id = _unitOfWork.LanguageRepository.GetAll().First(l => l.LangCode == langCode).Id;
            var result = GetByKey(Id);            
            return result;            
        }

        public OutLanguageDTO Insert(InLanguageDTO entity)
        {
            var lang = _mapper.Map<Language>(entity);

            _unitOfWork.LanguageRepository.Add(lang);            
            _unitOfWork.SaveChanges();

            var result = GetByKey(lang.Id);
            return result;
        }

        public OutLanguageDTO Update(InLanguageDTO entity)
        {
            var lang = _mapper.Map<Language>(entity);

            foreach(var key in lang.Keys)
            {
                key.LanguageId = lang.Id;
                _unitOfWork.KeyRepository.Update(key);                             
            }
            _unitOfWork.LanguageRepository.Update(lang);
            _unitOfWork.SaveChanges();

            var result = GetByKey(lang.Id);
            return result;
        }
    }
}
