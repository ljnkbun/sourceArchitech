using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingRoutings;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingRoutings
{
    public class CreateSewingRoutingsCommand : IRequest<Response<bool>>
    {
        public int SewingIEDId { get; set; }
        public virtual ICollection<SewingRoutingModel> SewingRoutings { get; set; }
    }
    public class CreateSewingRoutingsCommandHandler : IRequestHandler<CreateSewingRoutingsCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingRoutingRepository _repository;
        public CreateSewingRoutingsCommandHandler(IMapper mapper,
            ISewingRoutingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateSewingRoutingsCommand request, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<SewingRouting>>(request.SewingRoutings);
            if (entities == null || !entities.Any())
                return new Response<bool>(false);

            foreach (var entity in entities)
            {
                entity.SewingIEDId = request.SewingIEDId;
                entity.SMV = 0;
            }
            bool result = await _repository.AddRangeAsync(entities);
            return new Response<bool>(result);
        }
    }
}
