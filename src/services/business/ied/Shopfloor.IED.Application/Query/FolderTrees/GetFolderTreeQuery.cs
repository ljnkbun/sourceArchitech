using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.FolderTrees
{
    public class GetFolderTreeQuery : IRequest<Response<FolderTree>>
    {
        public int Id { get; set; }
    }
    public class GetFolderTreeQueryHandler : IRequestHandler<GetFolderTreeQuery, Response<FolderTree>>
    {
        private readonly IFolderTreeRepository _repository;
        public GetFolderTreeQueryHandler(IFolderTreeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<FolderTree>> Handle(GetFolderTreeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetFolderTreeByIdAsync(query.Id);
            if (entity == null) return new($"Folder Not Found (Id:{query.Id}).");
            return new Response<FolderTree>(entity);
        }
    }
}
