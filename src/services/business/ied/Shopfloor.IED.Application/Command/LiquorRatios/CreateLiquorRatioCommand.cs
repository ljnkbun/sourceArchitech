using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.LiquorRatios
{
    public class CreateLiquorRatioCommand : IRequest<Response<int>>
    {
        public decimal Value { get; set; }
    }
    public class CreateLiquorRatioCommandHandler : IRequestHandler<CreateLiquorRatioCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ILiquorRatioRepository _repository;
        public CreateLiquorRatioCommandHandler(IMapper mapper,
            ILiquorRatioRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateLiquorRatioCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<LiquorRatio>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
