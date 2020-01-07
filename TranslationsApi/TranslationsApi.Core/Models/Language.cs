using System.Collections.Generic;

namespace TranslationsApi.Core.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string LangCode { get; set; }
        public List<Key> Keys { get; set; }
    }
}
