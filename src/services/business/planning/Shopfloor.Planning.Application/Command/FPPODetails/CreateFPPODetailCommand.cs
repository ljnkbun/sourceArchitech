using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.FPPODetails
{
    public class CreateFPPODetailCommand : IRequest<Response<int>>
    {
        public int FPPOId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Quantity { get; set; }
    }
    public class CreateFPPODetailCommandHandler : IRequestHandler<CreateFPPODetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFPPODetailRepository _repository;
        public CreateFPPODetailCommandHandler(IMapper mapper, IFPPODetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(CreateFPPODetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FPPODetail>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
