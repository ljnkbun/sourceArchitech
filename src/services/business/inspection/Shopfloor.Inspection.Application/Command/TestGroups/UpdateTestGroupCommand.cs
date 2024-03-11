using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Command.TestGroups
{
    public class UpdateTestGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public GroupType GroupType { get; set; }
		public bool Mandatory { get; set; }
		public string Description { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateTestGroupCommandHandler : IRequestHandler<UpdateTestGroupCommand, Response<int>>
    {
        private readonly ITestGroupRepository _repository;
        public UpdateTestGroupCommandHandler(ITestGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateTestGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"TestGroup Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;
            entity.Buyer = command.Buyer;
			entity.Category = command.Category;
			entity.GroupType = command.GroupType;
			entity.Mandatory = command.Mandatory;
			entity.Description = command.Description;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
