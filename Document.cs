using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigiSigner.Client
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Document
    {
        [JsonIgnore]
        public string FileName
        {
            get; set;
        }

        [JsonProperty("document_id")]
        public string ID
        {
            get; set;
        }

        [JsonProperty("title")]
        public string Title
        {
            get; set;
        }

        [JsonProperty("subject")]
        public string Subject
        {
            get; set;
        }

        [JsonProperty("message")]
        public string Message
        {
            get; set;
        }

        [JsonProperty("signers")]
        public List<Signer> Signers
        {
            get; set;
        }


        public Document()
        {
            Signers = new List<Signer>();
        }


        public Document(string fileName)
        {
            FileName = fileName;

            Signers = new List<Signer>();
        }
    }
}
