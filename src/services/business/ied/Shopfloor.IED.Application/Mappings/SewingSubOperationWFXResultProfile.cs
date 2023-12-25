using AutoMapper;
using Shopfloor.IED.Application.Command.SewingSubOperationWFXResults;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXResults;
using Shopfloor.IED.Application.Parameters.SewingSubOperationWFXResults;
using Shopfloor.IED.Application.Query.SewingSubOperationWFXResults;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingSubOperationWFXResults
{
    public class SewingSubOperationWFXResultProfile : Profile
    {
        public SewingSubOperationWFXResultProfile()
        {
            CreateMap<SewingSubOperationWFXResultModel, SewingSubOperationWFXResult>();
            CreateMap<SewingSubOperationWFXResult, GetSewingSubOperationWFXResultModel>();
            CreateMap<CreateSewingSubOperationWFXResultCommand, SewingSubOperationWFXResult>();
            CreateMap<GetSewingSubOperationWFXResultsQuery, SewingSubOperationWFXResultParameter>();
            CreateMap<SewingSubOperationWFXResultModel, SewingSubOperationWFXResult>();
        }
    }
}
