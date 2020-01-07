namespace TranslationsApi.Core.Models
{
    public class Key
    {
        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string KeyName { get; set; }

        public string KeyValue { get; set; }       
    }
}
