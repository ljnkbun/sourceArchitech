using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ColorCards
{
    public class CreateColorCardCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string Reference { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string SelectColor { get; set; }
        public string PictureURL { get; set; }
    }
    public class CreateColorCardCommandHandler : IRequestHandler<CreateColorCardCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IColorCardRepository _repository;
        public CreateColorCardCommandHandler(IMapper mapper,
            IColorCardRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateColorCardCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ColorCard>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
