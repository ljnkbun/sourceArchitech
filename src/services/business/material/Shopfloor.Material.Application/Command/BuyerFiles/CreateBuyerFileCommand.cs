using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.BuyerFiles
{
    public class CreateBuyerFileCommand : IRequest<Response<int>>
    {
        public int BuyerId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }
    }

    public class CreateBuyerFileCommandHandler : IRequestHandler<CreateBuyerFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly IBuyerFileRepository _repository;

        public CreateBuyerFileCommandHandler(IMapper mapper, ILogger<CreateBuyerFileCommand> logger,
            IBuyerFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBuyerFileCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BuyerFile>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}