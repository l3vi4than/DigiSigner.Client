using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigiSigner.Client
{
    public class DocumentFields
    {
        [JsonProperty("document_fields")]
        public List<DocumentField> Fileds
        {
            get; set;
        }
    }
}
