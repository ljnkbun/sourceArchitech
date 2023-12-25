using AutoMapper;
using Shopfloor.Master.Application.Command.Certificates;
using Shopfloor.Master.Application.Models.Certificates;
using Shopfloor.Master.Application.Parameters.Certificates;
using Shopfloor.Master.Application.Query.Certificates;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class CertificateProfile : Profile
    {
        public CertificateProfile()
        {
            CreateMap<Certificate, CertificateModel>().ReverseMap();
            CreateMap<CreateCertificateCommand, Certificate>();
            CreateMap<GetCertificatesQuery, CertificateParameter>();
        }
    }
}
