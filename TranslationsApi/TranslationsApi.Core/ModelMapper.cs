using AutoMapper;
using TranslationsApi.Core.DTO;
using TranslationsApi.Core.Models;

namespace TranslationsApi.Core
{
    public class ModelMapper: Profile
    {
        public ModelMapper()
        {
            CreateMap<Key, KeyDTO>();

            CreateMap<KeyDTO, Key>();

            CreateMap<Language, OutLanguageDTO>()
                .ForMember(
                    dest => dest.Keys,
                    opt => opt.MapFrom<CustomResolver>()
                    );

            CreateMap<InLanguageDTO, Language>();
        }
    }
}
