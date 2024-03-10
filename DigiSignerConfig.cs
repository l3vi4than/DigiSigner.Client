namespace DigiSigner.Client
{
    public class DigiSignerConfig
    {
        private readonly string apiUrl;

        public DigiSignerConfig(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public string GetDocumentUrl() => $"{apiUrl}/documents";
        public string GetDocumentUrl(string documentId) => $"{GetDocumentUrl()}/{documentId}";
        public string GetFieldsUrl(string documentId) => $"{GetDocumentUrl()}/{documentId}/fields";
        public string GetContentUrl(string documentId) => $"{GetDocumentUrl()}/{documentId}/content";
        public string GetSignatureRequestsUrl() => $"{apiUrl}/signature_requests";
        public string GetSignatureRequestsUrl(string requestId) => $"{GetSignatureRequestsUrl()}/{requestId}";
        public string GetDeleteDocumentUrl(string documentId) => $"{GetDocumentUrl()}/{documentId}";
        public string GetDocumentAttachmentUrl(string documentId, string fieldApiId) => $"{GetDocumentUrl()}/{documentId}/fields/{fieldApiId}/attachment";
    }
}