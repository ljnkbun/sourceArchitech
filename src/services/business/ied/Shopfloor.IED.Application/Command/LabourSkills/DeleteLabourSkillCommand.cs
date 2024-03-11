using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.LabourSkills
{
    public class DeleteLabourSkillCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteLabourSkillCommandHandler : IRequestHandler<DeleteLabourSkillCommand, Response<int>>
    {
        private readonly ILabourSkillRepository _repository;
        public DeleteLabourSkillCommandHandler(ILabourSkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteLabourSkillCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"LabourSkill Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
