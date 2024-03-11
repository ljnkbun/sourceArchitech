using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingYarns;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingYarns
{
    public class CreateKnittingYarnsCommand : IRequest<Response<bool>>
    {
        public int KnittingIEDId { get; set; }
        public List<KnittingYarnModel> KnittingYarnModels { get; set; }
    }
    public class CreateKnittingYarnsCommandHandler : IRequestHandler<CreateKnittingYarnsCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingYarnRepository _repository;
        public CreateKnittingYarnsCommandHandler(IMapper mapper,
            IKnittingYarnRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateKnittingYarnsCommand request, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<KnittingYarn>>(request.KnittingYarnModels);
            if (entities == null || !entities.Any())
                return new Response<bool>(false);

            foreach (var entity in entities)
            {
                entity.KnittingIEDId = request.KnittingIEDId;
            }
            bool result = await _repository.AddRangeAsync(entities);
            return new Response<bool>(result);
        }
    }
}
