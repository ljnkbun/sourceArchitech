using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.TestGroups
{
    public class CreateTestGroupCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public GroupType GroupType { get; set; }
		public bool Mandatory { get; set; }
		public string Description { get; set; }
    }
    public class CreateTestGroupCommandHandler : IRequestHandler<CreateTestGroupCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ITestGroupRepository _repository;
        public CreateTestGroupCommandHandler(IMapper mapper,
            ITestGroupRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTestGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TestGroup>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
