using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.OneHundredPointSystems
{
    public class UpdateOneHundredPointSystemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public bool IsActive { set; get; }
    }
    public class UpdateOneHundredPointSystemCommandHandler : IRequestHandler<UpdateOneHundredPointSystemCommand, Response<int>>
    {
        private readonly IOneHundredPointSystemRepository _repository;
        public UpdateOneHundredPointSystemCommandHandler(IOneHundredPointSystemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateOneHundredPointSystemCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"OneHundredPointSystem Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
