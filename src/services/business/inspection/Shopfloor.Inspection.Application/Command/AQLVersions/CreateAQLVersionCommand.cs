using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.AQLs;

namespace Shopfloor.Inspection.Application.Command.AQLVersions
{
    public class CreateAQLVersionCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<CreateAQLCommand> AQLs { get; set; }
        
    }
    public class CreateAQLVersionCommandHandler : IRequestHandler<CreateAQLVersionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAQLVersionRepository _repository;
        public CreateAQLVersionCommandHandler(IMapper mapper,
            IAQLVersionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAQLVersionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<AQLVersion>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
