using AutoMapper;
using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Enums;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.PORDetails
{
    public class UpdatePORDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public int PORId { get; set; }
        public PorType? Type { get; set; }
        public bool IsActive { get; set; }
    }
    public class UpdatePORDetailCommandHandler : IRequestHandler<UpdatePORDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IPORDetailRepository _repository;
        public UpdatePORDetailCommandHandler(IMapper mapper
            , IPORDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdatePORDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"PORDetail Not Found.");

            entity.Color = command.Color;
            entity.Size = command.Size;
            entity.OrderedQuantity = command.OrderedQuantity;
            entity.RemainingQuantity = command.RemainingQuantity;
            entity.TypePORDetail = command.Type;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
