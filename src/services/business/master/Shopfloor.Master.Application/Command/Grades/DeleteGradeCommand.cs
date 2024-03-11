using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Grades
{
    public class DeleteGradeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand, Response<int>>
    {
        private readonly IGradeRepository _repository;
        public DeleteGradeCommandHandler(IGradeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteGradeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Grade Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
