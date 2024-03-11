using AutoMapper;
using Shopfloor.IED.Application.Command.RequestArticleInputs;
using Shopfloor.IED.Application.Models.RequestArticleInputs;
using Shopfloor.IED.Application.Parameters.RequestArticleInputs;
using Shopfloor.IED.Application.Query.RequestArticleInputs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.RequestArticleInputs
{
    public class RequestArticleInputProfile : Profile
    {
        public RequestArticleInputProfile()
        {
            CreateMap<RequestArticleInput, RequestArticleInputModel>().ReverseMap();
            CreateMap<CreateRequestArticleInputCommand, RequestArticleInput>();
            CreateMap<UpdateRequestArticleInputCommand, RequestArticleInput>();
            CreateMap<GetRequestArticleInputsQuery, RequestArticleInputParameter>();
        }
    }
}
