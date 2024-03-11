using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.Conversions
{
    public class UpdateConversionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateConversionCommandHandler : IRequestHandler<UpdateConversionCommand, Response<int>>
    {
        private readonly IConversionRepository _repository;
        public UpdateConversionCommandHandler(IConversionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateConversionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Conversion Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            entity.Value = command.Value;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
