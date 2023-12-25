using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SubCategories
{
    public class UpdateSubCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SubCategoryGroupId { get; set; }
        public string ExciseTarrifNo { get; set; }
        public bool PackagingUnit { get; set; }
        public bool ByPassPriceList { get; set; }
        public bool DefaultInactiveIndent { get; set; }
        public int ProductGroupId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommand, Response<int>>
    {
        private readonly ISubCategoryRepository _repository;
        public UpdateSubCategoryCommandHandler(ISubCategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateSubCategoryCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"SubCategory Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.SubCategoryGroupId = command.SubCategoryGroupId;
            entity.ExciseTarrifNo = command.ExciseTarrifNo;
            entity.PackagingUnit = command.PackagingUnit;
            entity.ByPassPriceList = command.ByPassPriceList;
            entity.DefaultInactiveIndent = command.DefaultInactiveIndent;
            entity.ProductGroupId = command.ProductGroupId;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
