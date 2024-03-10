using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigiSigner.Client
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SignatureRequest
    {
        public SignatureRequest()
        {
            SendEmails = true;
            Embedded = false;
            UseTextTags = false;
            HideTextTags = false;
            SendDocumentsAsBundle = false;
            Documents = new List<Document>();
            Branding = new Branding();
        }

        [JsonProperty("signature_request_id")]
        public string SignatureRequestId
        {
            get; set;
        }

        /*
          The parameter indicates that the email notifications will be sent.
         */
        [JsonProperty("send_emails")]
        public bool SendEmails
        {
            get; set;
        }

        /**
         * The embedded parameter indicates if the sign page has to be in embedded style mode.
         */
        [JsonProperty("embedded")]
        public bool Embedded
        {
            get; set;
        }

        [JsonProperty("redirect_for_signing_to_url")]
        public string RedirectForSigningToUrl
        {
            get; set;
        }

        [JsonProperty("redirect_after_signing_to_url")]
        public string RedirectAfterSigningToUrl
        {
            get; set;
        }

        [JsonProperty("use_text_tags")]
        public bool UseTextTags
        {
            get; set;
        }

        [JsonProperty("hide_text_tags")]
        public bool HideTextTags
        {
            get; set;
        }

        [JsonProperty("send_documents_as_bundle")]
        public bool SendDocumentsAsBundle
        {
            get; set;
        }

        [JsonProperty("bundle_title")]
        public string BundleTitle
        {
            get; set;
        }

        [JsonProperty("bundle_subject")]
        public string BundleSubject
        {
            get; set;
        }

        [JsonProperty("bundle_message")]
        public string BundleMessage
        {
            get; set;
        }

        [JsonProperty("is_completed")]
        public bool Completed
        {
            get; set;
        }

        [JsonProperty("documents")]
        public List<Document> Documents
        {
            get; set;
        }

        [JsonProperty("branding")]
        public Branding Branding
        {
            get; set;
        }
    }
}
