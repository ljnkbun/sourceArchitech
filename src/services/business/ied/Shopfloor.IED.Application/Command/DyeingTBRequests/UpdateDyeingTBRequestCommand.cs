using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBMaterials;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRequests
{
    public class UpdateDyeingTBRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int RecipeCategoryId { get; set; }

        public DateTime RequestDate { get; set; }

        public string StyleRef { get; set; }

        public string Remark { get; set; }

        public int? DyeingIEDId { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public DateTime ExpiredDate { get; set; }

        public TBRequestStatus Status { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UpdateDyeingTBMaterialCommand> DyeingTBMaterials { get; set; }
    }

    public class UpdateDyeingTBRequestCommandHandler : IRequestHandler<UpdateDyeingTBRequestCommand, Response<int>>
    {
        private readonly IDyeingTBRequestRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDyeingTBRequestCommandHandler(IDyeingTBRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateDyeingTBRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetWithIncludeByIdAsync(command.Id);
            if (entity == null) return new($"DyeingTBRequest Not Found.");
            entity.RequestDate = command.RequestDate;
            entity.BuyerRef = command.BuyerRef;
            entity.ExpiredDate = command.ExpiredDate;
            entity.Remark = command.Remark;
            entity.StyleRef = command.StyleRef;
            entity.RecipeCategoryId = command.RecipeCategoryId;
            entity.Buyer = command.Buyer;
            entity.Status = command.Status;
            entity.IsActive = command.IsActive;
            entity.DyeingIEDId = command.DyeingIEDId;
            var dbDyeingTBMaterialColors = entity.DyeingTBMaterials
                .SelectMany(x => x.DyeingTBMaterialColors).ToList();
            var dbDyeingTBMaterials = entity.DyeingTBMaterials.Select(x =>
            {
                x.DyeingTBMaterialColors = null;
                return x;
            }).ToList();

            var commandDyeingTBMaterialColors = command.DyeingTBMaterials
                .SelectMany(x => x.DyeingTBMaterialColors).ToList();
            var commandDyeingTBMaterials = command.DyeingTBMaterials.ToList();
            entity.DyeingTBMaterials = null;

            #region DyeingTBMaterial

            var dbDyeingTBMaterialModifieds = dbDyeingTBMaterials.Where(x => commandDyeingTBMaterials.Any(y => y.Id == x.Id)).Select(
                x =>
                {
                    var data = _mapper.Map(commandDyeingTBMaterials.First(c => c.Id == x.Id), x);
                    data.DyeingTBMaterialColors = null;
                    return data;
                });

            var newDyeingTBMaterialAddeds = commandDyeingTBMaterials.Where(x => x.Id == 0 && x.DyeingTBRequestId != 0)
                .Select(x => _mapper.Map<DyeingTBMaterial>(x));

            var dbDyeingTBMaterialDeletes =
                dbDyeingTBMaterials.Where(x => dbDyeingTBMaterialModifieds.All(y => y.Id != x.Id));

            #endregion DyeingTBMaterial

            #region DyeingTBMaterialColor

            var dbDyeingTBMaterialColorModifieds = dbDyeingTBMaterialColors.Where(x => commandDyeingTBMaterialColors.Any(y => y.Id == x.Id)).Select(x => _mapper.Map(commandDyeingTBMaterialColors.First(c => c.Id == x.Id), x));

            var newDyeingTBMaterialColorAddeds = commandDyeingTBMaterialColors.Where(x => x.Id == 0 && x.DyeingTBMaterialId != 0)
                .Select(x => _mapper.Map<DyeingTBMaterialColor>(x));

            var dbDyeingTBMaterialColorDeletes =
                dbDyeingTBMaterialColors.Where(x => dbDyeingTBMaterialColorModifieds.All(y => y.Id != x.Id));

            #endregion DyeingTBMaterialColor

            await _repository.UpdateDyeingTBRequestAsync(entity, new BaseUpdateEntity<DyeingTBMaterial>
            {
                LstDataAdd = newDyeingTBMaterialAddeds,
                LstDataDelete = dbDyeingTBMaterialDeletes,
                LstDataUpdate = dbDyeingTBMaterialModifieds
            }, new BaseUpdateEntity<DyeingTBMaterialColor>
            {
                LstDataAdd = newDyeingTBMaterialColorAddeds,
                LstDataDelete = dbDyeingTBMaterialColorDeletes,
                LstDataUpdate = dbDyeingTBMaterialColorModifieds
            });
            return new Response<int>(entity.Id);
        }
    }
}