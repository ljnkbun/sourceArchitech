using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DyeingTBMaterials;
using Shopfloor.IED.Application.Command.DyeingTBRequestFiles;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRequests
{
    public class CreateDyeingTBRequestCommand : IRequest<Response<int>>
    {
        public int RequestType { get; set; }

        public DateTime RequestDate { get; set; }

        public string StyleRef { get; set; }

        public string Remark { get; set; }

        public string Buyer { get; set; }

        public string BuyerRef { get; set; }

        public DateTime ExpiredDate { get; set; }

        public TBRequestStatus Status { get; set; }

        public virtual ICollection<CreateDyeingTBMaterialCommand> DyeingTBMaterials { get; set; }

        public virtual ICollection<CreateDyeingTBRequestFileCommand> DyeingTBRequestFiles { get; set; }
    }

    public class CreateDyeingTBRequestCommandHandler : IRequestHandler<CreateDyeingTBRequestCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRequestRepository _repository;

        public CreateDyeingTBRequestCommandHandler(IMapper mapper,
            IDyeingTBRequestRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDyeingTBRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DyeingTBRequest>(request);
            await _repository.AddDyeingTBRequestAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}