using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.FormulaFields
{
    public class CreateFormulaFieldCommand : IRequest<Response<int>>
    {
        public string FieldName { get; set; }
        public string Description { get; set; }
        public string ProcessCode { get; set; }

    }
    public class CreateFormulaFieldCommandHandler : IRequestHandler<CreateFormulaFieldCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFormulaFieldRepository _repository;
        public CreateFormulaFieldCommandHandler(IMapper mapper,
            IFormulaFieldRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFormulaFieldCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FormulaField>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
