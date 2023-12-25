using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingYarns
{
    public class CreateWeavingYarnCommand : IRequest<Response<int>>
    {
        public int WeavingArticleId { get; set; }
        public int LineNumber { get; set; }
        public YarnType YarnType { get; set; }
        public string YarnCode { get; set; }
        public string YarnName { get; set; }
        public decimal YarnInRappo { get; set; }
        public decimal YarnRatio { get; set; }
        public decimal SizingRatio { get; set; }
        public decimal ScaleRatio { get; set; }
        public decimal ScrapRatio { get; set; }
        public decimal Weight { get; set; }
    }
    public class CreateWeavingYarnCommandHandler : IRequestHandler<CreateWeavingYarnCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingYarnRepository _repository;
        public CreateWeavingYarnCommandHandler(IMapper mapper,
            IWeavingYarnRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingYarnCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingYarn>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
