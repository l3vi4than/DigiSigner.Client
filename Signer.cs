using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigiSigner.Client
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Signer
    {
        public Signer()
        {
            UseAllPdfFields = false;
            PdfFields = new List<PdfField>();
            Fields = new List<Field>();
            ExistingFields = new List<ExistingField>();
            SignatureCompleted = false;
        }

        public Signer(string email)
        {
            UseAllPdfFields = false;
            PdfFields = new List<PdfField>();
            Fields = new List<Field>();
            ExistingFields = new List<ExistingField>();
            SignatureCompleted = false;

            Email = email;
        }

        [JsonProperty("email")]
        public string Email
        {
            get; set;
        }

        [JsonProperty("role")]
        public string Role
        {
            get; set;
        }

        [JsonProperty("order")]
        public int? Order
        {
            get; set;
        }

        [JsonProperty("fields")]
        public List<Field> Fields
        {
            get; set;
        }

        [JsonProperty("pdf_fields")]
        public List<PdfField> PdfFields
        {
            get; set;
        }

        [JsonProperty("use_all_pdf_fields")]
        public bool UseAllPdfFields
        {
            get; set;
        }

        [JsonProperty("existing_fields")]
        public List<ExistingField> ExistingFields
        {
            get; set;
        }

        [JsonProperty("is_signature_completed")]
        public bool SignatureCompleted
        {
            get; set;
        }

        [JsonProperty("sign_document_url")]
        public string SignDocumentUrl
        {
            get; set;
        }

        [JsonProperty("access_code")]
        public string AccessCode
        {
            get; set;
        }
    }
}
