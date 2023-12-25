using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingMacroLibBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingMacroLibs
{
    public class CreateSewingMacroLibCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FolderTreeId { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalBasicMinutes { get; set; }
        public decimal NoneMachineTime { get; set; }
        public virtual ICollection<SewingMacroLibBOLModel> SewingMacroLibBOLs { get; set; }
    }
    public class CreateSewingMacroLibCommandHandler : IRequestHandler<CreateSewingMacroLibCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingMacroLibRepository _repository;
        public CreateSewingMacroLibCommandHandler(IMapper mapper,
            ISewingMacroLibRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingMacroLibCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingMacroLib>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
