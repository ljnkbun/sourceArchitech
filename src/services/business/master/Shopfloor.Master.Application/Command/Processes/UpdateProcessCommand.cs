using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Processes
{
    public class UpdateProcessCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
        public string DefaultArticleOutput { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductGroupId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? SubCategoryGroupId { get; set; }
        public int? DivisionId { get; set; }
    }

    public class UpdateProcessCommandHandler : IRequestHandler<UpdateProcessCommand, Response<int>>
    {
        private readonly IProcessRepository _repository;

        public UpdateProcessCommandHandler(IProcessRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateProcessCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Process Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.CategoryId = command.CategoryId;
            entity.SubCategoryId = command.SubCategoryId;
            entity.ProductGroupId = command.ProductGroupId;
            entity.SubCategoryGroupId = command.SubCategoryGroupId;
            entity.DivisionId = command.DivisionId;
            entity.IsActive = command.IsActive;
            entity.DefaultArticleOutput = command.DefaultArticleOutput;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}