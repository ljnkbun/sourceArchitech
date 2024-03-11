using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingRoutings;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingIEDs
{
    public class CreateDyeingIEDCommand : IRequest<Response<int>>
    {
        public int RequestArticleOutputId { get; set; }

        public string RequestNo { get; set; }

        public int? RequestTypeId { get; set; }

        public int WFXArticleId { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleName { get; set; }

        public string ProductGroup { get; set; }

        public string SubCategory { get; set; }

        public string Buyer { get; set; }

        public string Color { get; set; }

        public string ColorRef { get; set; }

        public int? RecipeId { get; set; }

        public Status Status { get; set; }

        public string Comment { get; set; }
        public string TCFNo { get; set; }
        public int? WFXInputMaterialId { get; set; }
        public string InputMaterialName { get; set; }

        public ICollection<CreateDyeingRoutingCommand> DyeingRoutings { get; set; }
    }

    public class CreateDyeingIEDCommandHandler : IRequestHandler<CreateDyeingIEDCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingIEDRepository _repository;

        public CreateDyeingIEDCommandHandler(IMapper mapper,
            IDyeingIEDRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingIEDCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingIED>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}