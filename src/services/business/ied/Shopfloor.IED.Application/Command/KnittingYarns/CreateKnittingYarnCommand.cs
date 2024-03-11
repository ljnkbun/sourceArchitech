using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingYarns
{
    public class CreateKnittingYarnCommand : IRequest<Response<int>>
    {
        public int KnittingIEDId { get; set; }
        public int LineNumber { get; set; }
        public int YarnId { get; set; }
        public string YarnName { get; set; }
        public string YarnCode { get; set; }
        public string Color { get; set; }
        public decimal YarnRatio { get; set; }
        public decimal Weight { get; set; }
        public decimal Wastage { get; set; }
    }
    public class CreateKnittingYarnCommandHandler : IRequestHandler<CreateKnittingYarnCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingYarnRepository _repository;
        public CreateKnittingYarnCommandHandler(IMapper mapper,
            IKnittingYarnRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingYarnCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingYarn>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
