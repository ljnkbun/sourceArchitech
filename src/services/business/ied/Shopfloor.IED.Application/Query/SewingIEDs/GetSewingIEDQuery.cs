using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingIEDs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingIEDs
{
    public class GetSewingIEDQuery : IRequest<Response<SewingIED>>
    {
        public int Id { get; set; }
    }
    public class GetSewingIEDQueryHandler : IRequestHandler<GetSewingIEDQuery, Response<SewingIED>>
    {
        private readonly ISewingIEDRepository _repository;

        public GetSewingIEDQueryHandler(ISewingIEDRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingIED>> Handle(GetSewingIEDQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetSewingIEDByIdAsync(query.Id);
            if (entity == null) return new($"SewingIED Not Found (Id:{query.Id}).");
            return new Response<SewingIED>(entity);
        }
    }
}
