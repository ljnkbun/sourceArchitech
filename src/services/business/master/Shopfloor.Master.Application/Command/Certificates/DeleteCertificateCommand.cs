using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Certificates
{
    public class DeleteCertificateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, Response<int>>
    {
        private readonly ICertificateRepository _repository;
        public DeleteCertificateCommandHandler(ICertificateRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCertificateCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Certificate Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
