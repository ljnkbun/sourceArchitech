using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.DefectCapturingStandards
{
    public class DeleteDefectCapturingStandardCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteDefectCapturingStandardCommandHandler : IRequestHandler<DeleteDefectCapturingStandardCommand, Response<int>>
    {
        private readonly IDefectCapturingStandardRepository _repository;
        public DeleteDefectCapturingStandardCommandHandler(IDefectCapturingStandardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteDefectCapturingStandardCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DefectCapturingStandard Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
