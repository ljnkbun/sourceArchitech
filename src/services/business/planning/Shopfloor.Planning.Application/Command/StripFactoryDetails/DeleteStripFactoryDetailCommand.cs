using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.StripFactoryDetails
{
    public class DeleteStripFactoryDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteStripFactoryDetailCommandHandler : IRequestHandler<DeleteStripFactoryDetailCommand, Response<int>>
    {
        private readonly IStripFactoryDetailRepository _repository;

        public DeleteStripFactoryDetailCommandHandler(IStripFactoryDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteStripFactoryDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return new($"StripFactoryDetail Not Found (Id:{request.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
