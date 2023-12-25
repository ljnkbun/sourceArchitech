using AutoMapper;
using Shopfloor.IED.Application.Command.RequestArticleOutputs;
using Shopfloor.IED.Application.Models.RequestArticleOutputs;
using Shopfloor.IED.Application.Parameters.RequestArticleOutputs;
using Shopfloor.IED.Application.Query.RequestArticleOutputs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.RequestArticleOutputs
{
    public class RequestArticleOutputProfile : Profile
    {
        public RequestArticleOutputProfile()
        {
            CreateMap<RequestArticleOutput, RequestArticleOutputModel>().ReverseMap();
            CreateMap<CreateRequestArticleOutputCommand, RequestArticleOutput>();
            CreateMap<GetRequestArticleOutputsQuery, RequestArticleOutputParameter>();
        }
    }
}
