﻿using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Strengths
{
    public class UpdateStrengthCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateStrengthCommandHandler : IRequestHandler<UpdateStrengthCommand, Response<int>>
    {
        private readonly IStrengthRepository _repository;
        public UpdateStrengthCommandHandler(IStrengthRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateStrengthCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Strength Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
