using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Formulas
{
    public class CreateFormulaCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Expression { get; set; }
        public string ProcessCode { get; set; }

    }
    public class CreateFormulaCommandHandler : IRequestHandler<CreateFormulaCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFormulaRepository _repository;
        public CreateFormulaCommandHandler(IMapper mapper,
            IFormulaRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFormulaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Formula>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
