using System.Collections.Generic;

namespace TranslationsApi.Core.DTO
{
    public class OutLanguageDTO
    {
        public string LangCode { get; set; }
        public Dictionary<string, string> Keys { get; set; }
    }
}
