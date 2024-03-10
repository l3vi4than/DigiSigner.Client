using Newtonsoft.Json;

namespace DigiSigner.Client
{
    public class PdfField
    {
        [JsonProperty("name")]
        public string Name// field name as specified in PDF document
        {
            get; set;
        }

        [JsonProperty("content")]
        public string Content
        {
            get; set;
        }

        [JsonProperty("label")]
        public string Label
        {
            get; set;
        }

        /**
         * If nothing is specified the default value for check boxes is false, but for all other fields it is true.
         */
        [JsonProperty("required")]
        public bool Required
        {
            get; set;
        }

        [JsonProperty("read_only")]
        public bool ReadOnly
        {
            get; set;
        }

        public PdfField()
        {
            ReadOnly = false;
        }

        public PdfField(string name)
        {
            Name = name;

            ReadOnly = false;
        }
    }
}
