using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingIEDs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingIEDs
{
    public class GetKnittingIEDQuery : IRequest<Response<KnittingIED>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingIEDQueryHandler : IRequestHandler<GetKnittingIEDQuery, Response<KnittingIED>>
    {
        private readonly IKnittingIEDRepository _repository;
        public GetKnittingIEDQueryHandler(IKnittingIEDRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingIED>> Handle(GetKnittingIEDQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetKnittingIEDByIdAsync(query.Id);
            if (entity == null) return new($"KnittingIED Not Found (Id:{query.Id}).");
            return new Response<KnittingIED>(entity);
        }
    }
}
