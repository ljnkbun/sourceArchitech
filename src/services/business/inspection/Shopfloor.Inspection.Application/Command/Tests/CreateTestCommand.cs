using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.Tests
{
    public class CreateTestCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public int TestGroupId { get; set; }
    }
    public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ITestRepository _repository;
        public CreateTestCommandHandler(IMapper mapper,
            ITestRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Test>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
