﻿using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Grades
{
    public class GetGradeQuery : IRequest<Response<Grade>>
    {
        public int Id { get; set; }
    }
    public class GetGradeQueryHandler : IRequestHandler<GetGradeQuery, Response<Grade>>
    {
        private readonly IGradeRepository _repository;
        public GetGradeQueryHandler(IGradeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Grade>> Handle(GetGradeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Grade Not Found (Id:{query.Id}).");
            return new Response<Grade>(entity);
        }
    }
}
