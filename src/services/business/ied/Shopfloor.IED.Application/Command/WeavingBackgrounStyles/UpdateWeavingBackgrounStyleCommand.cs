using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBackgrounStyles
{
    public class UpdateWeavingBackgrounStyleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingBackgrounStyleCommandHandler : IRequestHandler<UpdateWeavingBackgrounStyleCommand, Response<int>>
    {
        private readonly IWeavingBackgrounStyleRepository _repository;
        public UpdateWeavingBackgrounStyleCommandHandler(IWeavingBackgrounStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingBackgrounStyleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"WeavingBackgrounStyle Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
