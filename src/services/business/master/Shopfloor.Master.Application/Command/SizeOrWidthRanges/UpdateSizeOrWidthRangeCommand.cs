using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SizeOrWidthRanges
{
    public class UpdateSizeOrWidthRangeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateSizeOrWidthRangeCommandHandler : IRequestHandler<UpdateSizeOrWidthRangeCommand, Response<int>>
    {
        private readonly ISizeOrWidthRangeRepository _repository;
        public UpdateSizeOrWidthRangeCommandHandler(ISizeOrWidthRangeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateSizeOrWidthRangeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SizeOrWidthRange Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.SortOrder = command.SortOrder;
            entity.Inseam = command.Inseam;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
