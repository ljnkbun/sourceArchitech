using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Command.ProductGroupUOMs;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.UOMs
{
    public class UpdateUOMCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DecimalPlaces { get; set; }
        public int OrderDecimalPlaces { get; set; }
        public string Action { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateProductGroupUOMCommand> ProductGroupUOMs { get; set; }
    }

    public class UpdateUOMCommandHandler : IRequestHandler<UpdateUOMCommand, Response<int>>
    {
        private readonly IUOMRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUOMCommandHandler(IUOMRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateUOMCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(command.Id);

            if (entity == null) return new($"UOM Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.DecimalPlaces = command.DecimalPlaces;
            entity.OrderDecimalPlaces = command.OrderDecimalPlaces;
            entity.Action = command.Action;
            entity.IsActive = command.IsActive;

            #region ProductGroupUOM

            var newProductGroupUOMAddeds = command.ProductGroupUOMs.Where(x => x.Id == 0)
                .Select(x =>
                {
                    var data = _mapper.Map<ProductGroupUOM>(x);
                    data.UOMId = command.Id;
                    return data;
                });

            #endregion ProductGroupUOM

            await _repository.UpdateUOMAsync(entity, new BaseUpdateEntity<ProductGroupUOM>()
            {
                LstDataAdd = newProductGroupUOMAddeds,
                LstDataDelete = entity.ProductGroupUOMs
            });

            return new Response<int>(entity.Id);
        }
    }
}