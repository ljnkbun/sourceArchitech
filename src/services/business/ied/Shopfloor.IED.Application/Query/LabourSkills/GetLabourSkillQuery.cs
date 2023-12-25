using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.LabourSkills
{
    public class GetLabourSkillQuery : IRequest<Response<LabourSkill>>
    {
        public int Id { get; set; }
    }
    public class GetLabourSkillQueryHandler : IRequestHandler<GetLabourSkillQuery, Response<LabourSkill>>
    {
        private readonly ILabourSkillRepository _repository;
        public GetLabourSkillQueryHandler(ILabourSkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<LabourSkill>> Handle(GetLabourSkillQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"LabourSkill Not Found (Id:{query.Id}).");
            return new Response<LabourSkill>(entity);
        }
    }
}
