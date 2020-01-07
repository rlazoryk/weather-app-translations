using System.Collections.Generic;

namespace TranslationsApi.Core.DTO
{
    public class InLanguageDTO
    {
        public int Id { get; set; }

        public string LangCode { get; set; }

        public List<KeyDTO> Keys { get; set; }
    }
}
