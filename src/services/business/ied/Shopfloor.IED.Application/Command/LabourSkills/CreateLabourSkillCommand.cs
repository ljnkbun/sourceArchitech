using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.LabourSkills
{
    public class CreateLabourSkillCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateLabourSkillCommandHandler : IRequestHandler<CreateLabourSkillCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ILabourSkillRepository _repository;
        public CreateLabourSkillCommandHandler(IMapper mapper,
            ILabourSkillRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateLabourSkillCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<LabourSkill>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
