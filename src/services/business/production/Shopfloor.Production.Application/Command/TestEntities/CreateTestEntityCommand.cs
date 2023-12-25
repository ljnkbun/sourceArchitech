using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Enums;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.TestEntities
{
    public class CreateTestEntityCommand : IRequest<Response<int>>
    {
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType Type { get; set; }
    }
    public class CreateTestEntityCommandHandler : IRequestHandler<CreateTestEntityCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ITestEntityRepository _repository;
        public CreateTestEntityCommandHandler(IMapper mapper,
            ITestEntityRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTestEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TestEntity>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
