using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.FolderTrees
{
    public class CreateFolderTreeCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ItemType ItemType { get; set; }
        public DivisionType DivisionType { get; set; }
    }
    public class CreateFolderTreeCommandHandler : IRequestHandler<CreateFolderTreeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IFolderTreeRepository _repository;
        public CreateFolderTreeCommandHandler(IMapper mapper,
            IFolderTreeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFolderTreeCommand request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<FolderTree>(request);
            entity.Level = await GetNodeLevel(request.ParentId ?? 0);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }

        private async Task<byte> GetNodeLevel(int parentId)
        {
            byte levelOfRoot = 1;
            if (parentId == 0)
            {
                return levelOfRoot;
            }

            var parentNode = await _repository.GetByIdAsync(parentId);
            return (byte)((parentNode?.Level ?? 0) + 1);
        }
    }
}
