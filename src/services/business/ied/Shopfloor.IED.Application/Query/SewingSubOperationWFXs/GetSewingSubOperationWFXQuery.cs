using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingOperationWFXs;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingSubOperationWFXs
{
    public class GetSewingSubOperationWFXQuery : IRequest<Response<SewingSubOperationWFX>>
    {
        public int Id { get; set; }
    }
    public class GetSewingSubOperationWFXQueryHandler : IRequestHandler<GetSewingSubOperationWFXQuery, Response<SewingSubOperationWFX>>
    {
        private readonly ISewingSubOperationWFXRepository _subOperationWFXRepository;

        public GetSewingSubOperationWFXQueryHandler(ISewingSubOperationWFXRepository subOperationWFXRepository)
        {
            _subOperationWFXRepository = subOperationWFXRepository;
        }
        public async Task<Response<SewingSubOperationWFX>> Handle(GetSewingSubOperationWFXQuery query, CancellationToken cancellationToken)
        {
            var entity = await _subOperationWFXRepository.GetSewingSubOperationWFXByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SewingSubOperationWFX Not Found (Id:{query.Id}).");
            return new Response<SewingSubOperationWFX>(entity);
        }
    }
}
