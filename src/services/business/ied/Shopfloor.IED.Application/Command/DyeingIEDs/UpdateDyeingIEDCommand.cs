using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingRoutings;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingIEDs
{
    public class UpdateDyeingIEDCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int WFXArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public int? RecipeId { get; set; }

        public string Comment { get; set; }
        public string TCFNo { get; set; }
        public int? WFXInputMaterialId { get; set; }
        public string InputMaterialName { get; set; }
        public ICollection<DyeingRoutingModel> DyeingRoutings { get; set; }
    }

    public class UpdateDyeingIEDCommandHandler : IRequestHandler<UpdateDyeingIEDCommand, Response<int>>
    {
        private readonly IDyeingIEDRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDyeingIEDCommandHandler(IDyeingIEDRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateDyeingIEDCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"DyeingIED Not Found.");

            entity.WFXArticleId = command.WFXArticleId;
            entity.ArticleCode = command.ArticleCode;
            entity.ArticleName = command.ArticleName;
            entity.RecipeId = command.RecipeId;
            entity.Comment = command.Comment;
            entity.TCFNo = command.TCFNo;
            entity.WFXInputMaterialId = command.WFXInputMaterialId;
            entity.InputMaterialName = command.InputMaterialName;
            entity.DyeingRoutings = null;

            var newDyeingRoutings = _mapper.Map<List<DyeingRouting>>(command.DyeingRoutings);
            foreach (var item in newDyeingRoutings ?? Enumerable.Empty<DyeingRouting>())
            {
                item.DyeingIEDId = entity.Id;
            }
            await _repository.UpdateDyeingIEDAsync(entity, newDyeingRoutings);
            return new Response<int>(entity.Id);
        }
    }
}