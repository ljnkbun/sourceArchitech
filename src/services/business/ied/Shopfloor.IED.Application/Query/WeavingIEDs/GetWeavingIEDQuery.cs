﻿using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingIEDs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingIEDs
{
    public class GetWeavingIEDQuery : IRequest<Response<WeavingIED>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingIEDQueryHandler : IRequestHandler<GetWeavingIEDQuery, Response<WeavingIED>>
    {
        private readonly IWeavingIEDRepository _repository;
        public GetWeavingIEDQueryHandler(IWeavingIEDRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingIED>> Handle(GetWeavingIEDQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWeavingIEDByIdAsync(query.Id);
            if (entity == null) return new($"WeavingIED Not Found (Id:{query.Id}).");
            return new Response<WeavingIED>(entity);
        }
    }
}
