using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.BuyerFiles
{
    public class UpdateBuyerFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int BuyerId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateBuyerFileCommandHandler : IRequestHandler<UpdateBuyerFileCommand, Response<int>>
    {
        private readonly IBuyerFileRepository _repository;

        public UpdateBuyerFileCommandHandler(IBuyerFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateBuyerFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if(entity == null) return new($"BuyerFile Not Found.");
            entity.FileId = command.FileId;
            entity.Description = command.Description;
            entity.FileName = command.FileName;
            entity.BuyerId = command.BuyerId;
            entity.FileType = command.FileType;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}