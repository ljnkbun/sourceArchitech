using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ColorCards
{
    public class UpdateColorCardCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string Reference { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string SelectColor { get; set; }
        public string PictureURL { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateColorCardCommandHandler : IRequestHandler<UpdateColorCardCommand, Response<int>>
    {
        private readonly IColorCardRepository _repository;
        public UpdateColorCardCommandHandler(IColorCardRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateColorCardCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"ColorCard Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.GroupId = command.GroupId;
            entity.Reference = command.Reference;
            entity.BuyerCode = command.BuyerCode;
            entity.BuyerName = command.BuyerName;
            entity.SelectColor = command.SelectColor;
            entity.PictureURL = command.PictureURL;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
