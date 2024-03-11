using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Countries
{
    public class DeleteCountryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Response<int>>
    {
        private readonly ICountryRepository _repository;
        public DeleteCountryCommandHandler(ICountryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Country Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
