using System.Collections.Generic;

namespace DigiSigner.Client
{
    public class DocumentContent
    {
        DocumentContent()
        {
        }

        public DocumentContent(List<Signature> signatures)
        {
            Signatures = signatures;
        }

        public List<Signature> Signatures
        {
            get;
            private set;
        }
    }
}
