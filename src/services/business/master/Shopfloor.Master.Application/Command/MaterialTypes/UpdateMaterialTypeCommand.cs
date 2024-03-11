using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.CategoryMapMaterialTypes;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.MaterialTypes
{
    public class UpdateMaterialTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<UpdateCategoryMapMaterialTypeCommand> CategoryMapMaterialTypes { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateMaterialTypeCommandHandler : IRequestHandler<UpdateMaterialTypeCommand, Response<int>>
    {
        private readonly IMaterialTypeRepository _repository;
        private readonly IMapper _mapper;
        public UpdateMaterialTypeCommandHandler(IMaterialTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateMaterialTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetMaterialTypeByIdAsync(command.Id);

            if (entity == null) return new ($"MaterialType Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            var dbCategoryMapMaterialTypes = entity.CategoryMapMaterialTypes;
            entity.CategoryMapMaterialTypes = null;

            #region CategoryMapMaterialType

            var dbCategoryMapMaterialTypeModifieds = dbCategoryMapMaterialTypes.Where(x => command.CategoryMapMaterialTypes.Any(y => y.Id == x.Id)).Select(
                x =>
                {
                    var data = _mapper.Map(command.CategoryMapMaterialTypes.First(c => c.Id == x.Id), x);
                    data.MaterialTypeId = command.Id;
                    return data;
                });

            var newCategoryMapMaterialTypeAddeds = command.CategoryMapMaterialTypes.Where(x => x.Id == 0)
                .Select(x =>
                {
                    var data = _mapper.Map<CategoryMapMaterialType>(x);
                    data.MaterialTypeId = command.Id;
                    return data;
                });

            var dbCategoryMapMaterialTypeDeletes =
                dbCategoryMapMaterialTypes.Where(x => dbCategoryMapMaterialTypeModifieds.All(y => y.Id != x.Id));

            #endregion CategoryMapMaterialType

            await _repository.UpdateMaterialTypeAsync(entity, new BaseUpdateEntity<CategoryMapMaterialType>()
            {
                LstDataUpdate = dbCategoryMapMaterialTypeModifieds,
                LstDataAdd = newCategoryMapMaterialTypeAddeds,
                LstDataDelete = dbCategoryMapMaterialTypeDeletes
            });
            return new Response<int>(entity.Id);
        }
    }
}
