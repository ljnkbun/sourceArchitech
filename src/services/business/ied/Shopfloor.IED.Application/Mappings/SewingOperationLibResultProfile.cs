using AutoMapper;
using Shopfloor.IED.Application.Command.SewingOperationLibResults;
using Shopfloor.IED.Application.Models.SewingOperationLibResults;
using Shopfloor.IED.Application.Parameters.SewingOperationLibResults;
using Shopfloor.IED.Application.Query.SewingOperationLibResults;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingOperationLibResults
{
    public class SewingOperationLibResultProfile : Profile
    {
        public SewingOperationLibResultProfile()
        {
            CreateMap<SewingOperationLibResultModel, SewingOperationLibResult>().ReverseMap();
            CreateMap<SewingOperationLibResult, GetSewingOperationLibResultModel>();
            CreateMap<CreateSewingOperationLibResultCommand, SewingOperationLibResult>();
            CreateMap<GetSewingOperationLibResultsQuery, SewingOperationLibResultParameter>();
        }
    }
}
