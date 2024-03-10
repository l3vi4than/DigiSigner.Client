using Newtonsoft.Json;

namespace DigiSigner.Client
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ExistingField
    {
        [JsonProperty("api_id")]
        public string ApiId
        {
            get; set;
        }

        [JsonProperty("group_id")]
        public string GroupId
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


        public ExistingField()
        {
        }

        public ExistingField(string apiId)
        {
            ApiId = apiId;
        }
    }
}
