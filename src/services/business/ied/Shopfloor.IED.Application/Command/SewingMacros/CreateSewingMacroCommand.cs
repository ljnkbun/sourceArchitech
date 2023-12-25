using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingMacroBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingMacros
{
    public class CreateSewingMacroCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BundleTMU { get; set; }
        public decimal ManualTMU { get; set; }
        public decimal MachineTMU { get; set; }
        public decimal TotalBasicMinutes { get; set; }
        public decimal NoneMachineTime { get; set; }
        public virtual ICollection<SewingMacroBOLModel> SewingMacroBOLs { get; set; }
    }
    public class CreateSewingMacroCommandHandler : IRequestHandler<CreateSewingMacroCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingMacroRepository _repository;
        public CreateSewingMacroCommandHandler(IMapper mapper,
            ISewingMacroRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingMacroCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingMacro>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
