using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBorderStyles
{
    public class UpdateWeavingBorderStyleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingBorderStyleCommandHandler : IRequestHandler<UpdateWeavingBorderStyleCommand, Response<int>>
    {
        private readonly IWeavingBorderStyleRepository _repository;
        public UpdateWeavingBorderStyleCommandHandler(IWeavingBorderStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingBorderStyleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"WeavingBorderStyle Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
