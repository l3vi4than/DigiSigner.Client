using Newtonsoft.Json;

namespace DigiSigner.Client
{
    public class DocumentField
    {
        public DocumentField()
        {
            ReadOnly = false;
            PdfField = false;
        }

        [JsonProperty("api_id")]
        public string ApiId
        {
            get; set;
        }

        [JsonProperty("role")]
        public string Role
        {
            get; set;
        }

        [JsonProperty("type")]
        public FieldType Type
        {
            get; set;
        }

        [JsonProperty("page")]
        public int Page  // starts with 0
        {
            get; set;
        }

        [JsonProperty("rectangle")]
        public int[] Rectangle
        {
            get; set;
        }

        [JsonProperty("status")]
        public DocumentFieldStatus Status
        {
            get; set;
        }

        [JsonProperty("content")]
        public string Content;

        [JsonProperty("submitted_content")]
        public string SubmittedContent
        {
            get; set;
        }

        [JsonProperty("label")]
        public string Label
        {
            get; set;
        }

        [JsonProperty("required")]
        public bool Required
        {
            get; set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get; set;
        }

        [JsonProperty("group_id")]
        public string GroupId
        {
            get; set;
        }

        [JsonProperty("index")]
        public int Index  // relevant only for check boxes
        {
            get; set;
        }


        [JsonProperty("read_only")]
        public bool ReadOnly
        {
            get;
            set;
        }

        [JsonProperty("pdf_field")]
        public bool PdfField
        {
            get; set;
        }

        [JsonProperty("font_size")]
        private float FontSize
        {
            get; set;
        }


        [JsonProperty("max_length")]
        public int MaxLength
        {
            get; set;
        }

        [JsonProperty("alignment")]
        public DocumentFieldAlignment Alignment
        {
            get; set;
        }
    }
}
