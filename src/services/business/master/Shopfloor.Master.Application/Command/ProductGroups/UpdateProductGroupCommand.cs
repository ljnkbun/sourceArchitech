using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.MaterialTypeMapProductGroups;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProductGroups
{
    public class UpdateProductGroupCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public ICollection<UpdateMaterialTypeMapProductGroupCommand> MaterialTypeMapProductGroups { get; set; }

        public bool IsActive { set; get; }
    }
    public class UpdateProductGroupCommandHandler : IRequestHandler<UpdateProductGroupCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProductGroupRepository _repository;

        public UpdateProductGroupCommandHandler(IProductGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateProductGroupCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetProductGroupByIdAsync(command.Id);

            if (entity == null) return new($"ProductGroup Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.CategoryId = command.CategoryId;
            entity.IsActive = command.IsActive;

            var dbMaterialTypeMapProductGroups = entity.MaterialTypeMapProductGroups;
            entity.MaterialTypeMapProductGroups = null;

            #region MaterialTypeMapProductGroup

            var dbMaterialTypeMapProductGroupModifieds = dbMaterialTypeMapProductGroups.Where(x => command.MaterialTypeMapProductGroups.Any(y => y.Id == x.Id)).Select(
                x =>
                {
                    var data = _mapper.Map(command.MaterialTypeMapProductGroups.First(c => c.Id == x.Id), x);
                    data.ProductGroupId = command.Id;
                    return data;
                });

            var newMaterialTypeMapProductGroupAddeds = command.MaterialTypeMapProductGroups.Where(x => x.Id == 0)
                .Select(x =>
                {
                    var data = _mapper.Map<MaterialTypeMapProductGroup>(x);
                    data.ProductGroupId = command.Id;
                    return data;
                });

            var dbMaterialTypeMapProductGroupDeletes =
                dbMaterialTypeMapProductGroups.Where(x => dbMaterialTypeMapProductGroupModifieds.All(y => y.Id != x.Id));

            #endregion MaterialTypeMapProductGroup

            await _repository.UpdateProductGroupAsync(entity, new BaseUpdateEntity<MaterialTypeMapProductGroup>()
            {
                LstDataUpdate = dbMaterialTypeMapProductGroupModifieds,
                LstDataAdd = newMaterialTypeMapProductGroupAddeds,
                LstDataDelete = dbMaterialTypeMapProductGroupDeletes
            });

            return new Response<int>(entity.Id);
        }
    }
}
