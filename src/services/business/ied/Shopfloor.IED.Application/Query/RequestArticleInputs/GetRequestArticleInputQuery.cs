﻿using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestArticleInputs
{
    public class GetRequestArticleInputQuery : IRequest<Response<RequestArticleInput>>
    {
        public int Id { get; set; }
    }
    public class GetRequestArticleInputQueryHandler : IRequestHandler<GetRequestArticleInputQuery, Response<RequestArticleInput>>
    {
        private readonly IRequestArticleInputRepository _repository;
        public GetRequestArticleInputQueryHandler(IRequestArticleInputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<RequestArticleInput>> Handle(GetRequestArticleInputQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"RequestArticleInput Not Found (Id:{query.Id}).");
            return new Response<RequestArticleInput>(entity);
        }
    }
}
