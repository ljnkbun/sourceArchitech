using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.LabourSkills
{
    public class UpdateLabourSkillCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateLabourSkillCommandHandler : IRequestHandler<UpdateLabourSkillCommand, Response<int>>
    {
        private readonly ILabourSkillRepository _repository;
        public UpdateLabourSkillCommandHandler(ILabourSkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateLabourSkillCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"LabourSkills Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
