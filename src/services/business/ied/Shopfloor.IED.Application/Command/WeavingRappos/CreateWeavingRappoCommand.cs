using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRappos
{
    public class CreateWeavingRappoCommand : IRequest<Response<int>>
    {
        public int WeavingArticleId { get; set; }
        public int NumOfLine { get; set; }
        public int YarnOfBorder { get; set; }
        public int YarnOfBackground { get; set; }
        public int NumOfRappo { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
    }
    public class CreateWeavingRappoCommandHandler : IRequestHandler<CreateWeavingRappoCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRappoRepository _repository;
        public CreateWeavingRappoCommandHandler(IMapper mapper,
            IWeavingRappoRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingRappoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingRappo>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
