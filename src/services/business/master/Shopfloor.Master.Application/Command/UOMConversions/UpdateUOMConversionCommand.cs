using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.UOMConversions
{
    public class UpdateUOMConversionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int FromUOMId { get; set; }
        public int ToUOMId { get; set; }
        public decimal Value { get; set; }
        public string Action { get; set; } public bool IsActive { set; get; }
    }
    public class UpdateUOMConversionCommandHandler : IRequestHandler<UpdateUOMConversionCommand, Response<int>>
    {
        private readonly IUOMConversionRepository _repository;
        public UpdateUOMConversionCommandHandler(IUOMConversionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateUOMConversionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"UOMConversion Not Found.");

            entity.FromUOMId = command.FromUOMId;
            entity.ToUOMId = command.ToUOMId;
            entity.Value = command.Value;
            entity.Action = command.Action;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
