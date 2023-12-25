using MediatR;
using Shopfloor.Consumption.Domain.Enums;
using Shopfloor.Consumption.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Consumption.Application.Command.TestEntities
{
    public class UpdateTestEntityCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType Type { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateTestEntityCommandHandler : IRequestHandler<UpdateTestEntityCommand, Response<int>>
    {
        private readonly ITestEntityRepository _repository;
        public UpdateTestEntityCommandHandler(ITestEntityRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateTestEntityCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"TestEntity Not Found.");

            entity.Property01 = command.Property01;
            entity.Property02 = command.Property02;
            entity.Type = command.Type;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
