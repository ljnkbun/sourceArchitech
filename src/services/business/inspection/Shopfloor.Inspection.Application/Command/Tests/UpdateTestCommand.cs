using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.Tests
{
    public class UpdateTestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public int TestGroupId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateTestCommandHandler : IRequestHandler<UpdateTestCommand, Response<int>>
    {
        private readonly ITestRepository _repository;
        public UpdateTestCommandHandler(ITestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateTestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Test Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            entity.Description = command.Description;
			entity.TestGroupId = command.TestGroupId;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
