﻿using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Certificates
{
    public class UpdateCertificateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateCertificateCommandHandler : IRequestHandler<UpdateCertificateCommand, Response<int>>
    {
        private readonly ICertificateRepository _repository;
        public UpdateCertificateCommandHandler(ICertificateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateCertificateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Certificate Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
