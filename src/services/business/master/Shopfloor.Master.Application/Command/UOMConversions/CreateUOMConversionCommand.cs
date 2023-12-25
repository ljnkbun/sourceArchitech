using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.UOMConversions
{
    public class CreateUOMConversionCommand : IRequest<Response<int>>
    {
        public int FromUOMId { get; set; }
        public int ToUOMId { get; set; }
        public decimal? Value { get; set; }
        public string Action { get; set; }
    }
    public class CreateUOMConversionCommandHandler : IRequestHandler<CreateUOMConversionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUOMConversionRepository _repository;
        public CreateUOMConversionCommandHandler(IMapper mapper,
            IUOMConversionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUOMConversionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UOMConversion>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
