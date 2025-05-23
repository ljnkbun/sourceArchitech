﻿using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.UOMConversions
{
    public class GetUOMConversionQuery : IRequest<Response<UOMConversion>>
    {
        public int Id { get; set; }
    }
    public class GetUOMConversionQueryHandler : IRequestHandler<GetUOMConversionQuery, Response<UOMConversion>>
    {
        private readonly IUOMConversionRepository _repository;
        public GetUOMConversionQueryHandler(IUOMConversionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<UOMConversion>> Handle(GetUOMConversionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"UOMConversion Not Found (Id:{query.Id}).");
            return new Response<UOMConversion>(entity);
        }
    }
}
