using AutoMapper;
using System.Collections.Generic;
using TranslationsApi.Core.DTO;
using TranslationsApi.Core.Models;

namespace TranslationsApi.Core
{
    public class CustomResolver : IValueResolver<Language, OutLanguageDTO, Dictionary<string, string>>
    {
        public Dictionary<string, string> Resolve(Language source, OutLanguageDTO destination, Dictionary<string, string> destMember, ResolutionContext context)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach(var lan in source.Keys)
            {
                dictionary.Add(lan.KeyName, lan.KeyValue);
            }
            return dictionary;
        }
    }
}
