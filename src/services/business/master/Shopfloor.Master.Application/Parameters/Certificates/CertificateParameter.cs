using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Certificates
{
    public class CertificateParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
