﻿using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Origins
{
    public class DeleteOriginCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteOriginCommandHandler : IRequestHandler<DeleteOriginCommand, Response<int>>
    {
        private readonly IOriginRepository _repository;
        public DeleteOriginCommandHandler(IOriginRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteOriginCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Origin Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
