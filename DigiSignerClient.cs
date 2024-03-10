using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DigiSigner.Client
{
    public class DigiSignerClient(string apiKey, string apiUrl = DigiSignerClient.DefaultApiUrl)
    {
        public const string DefaultApiUrl = "https://api.digisigner.com/v1";

        private readonly string key = apiKey;
        private readonly DigiSignerConfig cfg = new(apiUrl);

        private void AddAuthInfo(WebHeaderCollection headers)
        {
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(key + ":"));
            headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
        }

        public string UploadDocument(string fileName)
        {
            using var webClient = CreateWebClient();

            var result = webClient.UploadFile(cfg.GetDocumentUrl(), fileName);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(Encoding.UTF8.GetString(result))["document_id"];
        }

        public void DeleteDocument(string documentId)
        {
            var webRequest = CreateWebRequest(cfg.GetDeleteDocumentUrl(documentId), "DELETE");
            webRequest.GetResponse();
        }

        public async Task DeleteDocumentAsync(string documentId)
        {
            var webRequest = CreateWebRequest(cfg.GetDeleteDocumentUrl(documentId), "DELETE");
            await webRequest.GetResponseAsync();
        }

        public void GetDocumentById(string documentId, string fileName)
        {
            using WebClient webClient = CreateWebClient();

            webClient.DownloadFile(cfg.GetDocumentUrl(documentId), fileName);
        }

        public void AddContentToDocument(string documentId, List<Signature> signatures)
        {
            var webRequest = CreateWebRequest(cfg.GetContentUrl(documentId), "POST");
            WriteBodyRequest(webRequest, JsonConvert.SerializeObject(new DocumentContent(signatures), Formatting.Indented));
            webRequest.GetResponse();
        }

        public async Task AddContentToDocumentAsync(string documentId, List<Signature> signatures)
        {
            var webRequest = CreateWebRequest(cfg.GetContentUrl(documentId), "POST");
            await WriteBodyRequestAsync(webRequest, JsonConvert.SerializeObject(new DocumentContent(signatures), Formatting.Indented));
            webRequest.GetResponse();
        }

        public DocumentFields GetDocumentFields(string documentId)
        {
            var webRequest = CreateWebRequest(cfg.GetFieldsUrl(documentId));
            return ReadFromBody<DocumentFields>(webRequest.GetResponse());
        }

        public async Task<DocumentFields> GetDocumentFieldsAsync(string documentId)
        {
            var webRequest = CreateWebRequest(cfg.GetFieldsUrl(documentId));
            return await ReadFromBodyAsync<DocumentFields>(webRequest.GetResponse());
        }

        public SignatureRequest GetSignatureRequest(string requestId)
        {
            var webRequest = CreateWebRequest(cfg.GetSignatureRequestsUrl(requestId));
            return ReadFromBody<SignatureRequest>(webRequest.GetResponse());
        }

        public async Task<SignatureRequest> GetSignatureRequestAsync(string requestId)
        {
            var webRequest = CreateWebRequest(cfg.GetSignatureRequestsUrl(requestId));
            return await ReadFromBodyAsync<SignatureRequest>(webRequest.GetResponse());
        }

        public SignatureRequest SendSignatureRequest(SignatureRequest request)
        {
            request.Documents.FindAll(d => d.ID == null).ForEach(d => d.ID = UploadDocument(d.FileName));

            var webRequest = CreateWebRequest(cfg.GetSignatureRequestsUrl(), "POST");
            WriteBodyRequest(webRequest, JsonConvert.SerializeObject(request, Formatting.Indented));
            return ReadFromBody<SignatureRequest>(webRequest.GetResponse());
        }

        public async Task<SignatureRequest> SendSignatureRequestAsync(SignatureRequest request)
        {
            request.Documents.FindAll(d => d.ID == null).ForEach(d => d.ID = UploadDocument(d.FileName));

            var webRequest = CreateWebRequest(cfg.GetSignatureRequestsUrl(), "POST");
            await WriteBodyRequestAsync(webRequest, JsonConvert.SerializeObject(request, Formatting.Indented));
            return ReadFromBody<SignatureRequest>(webRequest.GetResponse());
        }

        private static void WriteBodyRequest(HttpWebRequest request, string json)
        {
            var buffer = Encoding.UTF8.GetBytes(json);

            request.ContentLength = buffer.Length;
            request.ContentType = "application/json";

            using var dataStream = request.GetRequestStream();

            dataStream.Write(buffer, 0, buffer.Length);
            dataStream.Flush();
        }

        private static async Task WriteBodyRequestAsync(HttpWebRequest request, string json)
        {
            var buffer = Encoding.UTF8.GetBytes(json);

            request.ContentLength = buffer.Length;
            request.ContentType = "application/json";

            using var dataStream = request.GetRequestStream();

            await dataStream.WriteAsync(buffer);
            await dataStream.FlushAsync();
        }

        private static T ReadFromBody<T>(WebResponse response)
        {
            using var stream = response.GetResponseStream();

            var buffer = new byte[response.ContentLength];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            var json = Encoding.ASCII.GetString(buffer);

            return JsonConvert.DeserializeObject<T>(json);
        }

        private static async Task<T> ReadFromBodyAsync<T>(WebResponse response)
        {
            using var stream = response.GetResponseStream();

            var buffer = new byte[response.ContentLength];
            await stream.ReadAsync(buffer);
            stream.Close();

            var json = Encoding.ASCII.GetString(buffer);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public void GetDocumentAttachment(string documentId, string fieldApiId, string fileName)
        {
            using var webClient = CreateWebClient();

            webClient.DownloadFile(cfg.GetDocumentAttachmentUrl(documentId, fieldApiId), fileName);
        }

        private WebClient CreateWebClient()
        {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var client = new WebClient();
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            AddAuthInfo(client.Headers);
            return client;
        }

        private HttpWebRequest CreateWebRequest(string url, string method = "GET")
        {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var req = (HttpWebRequest)WebRequest.Create(url);
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            AddAuthInfo(req.Headers);
            req.Method = method;
            return req;
        }
    }
}
