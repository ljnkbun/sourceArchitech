using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingFeatureLibBOLs;
using Shopfloor.IED.Application.Models.SewingMacroLibBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFeatureLibs
{
    public class CreateSewingFeatureLibCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FolderTreeId { get; set; }
        public virtual ICollection<SewingFeatureLibBOLModel> SewingFeatureLibBOLs { get; set; }
    }
    public class CreateSewingFeatureLibCommandHandler : IRequestHandler<CreateSewingFeatureLibCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingFeatureLibRepository _repository;
        public CreateSewingFeatureLibCommandHandler(IMapper mapper,
            ISewingFeatureLibRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingFeatureLibCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingFeatureLib>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
