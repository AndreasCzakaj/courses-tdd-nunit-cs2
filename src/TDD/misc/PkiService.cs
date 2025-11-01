using System;

namespace TDD.Misc
{
    public class PkiService
    {
        public string CreateSignedCertificateForCsr(string csrAsBase64, DateTime notBefore, DateTime notAfter, string type, string uid)
        {
            // openssl pki magic....
            return "LS0tL...tLS0K";
        }
    }
}