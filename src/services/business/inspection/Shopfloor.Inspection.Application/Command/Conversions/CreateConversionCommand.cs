using AutoMapper;
using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.Conversions
{
    public class CreateConversionCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

    }
    public class CreateConversionCommandHandler : IRequestHandler<CreateConversionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IConversionRepository _repository;
        public CreateConversionCommandHandler(IMapper mapper,
            IConversionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateConversionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Conversion>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
