using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.FolderTrees
{
    public class GetAllFolderTreeQuery : IRequest<Response<IReadOnlyList<FolderTree>>>
    {
    }
    public class GetAllFolderTreeQueryHandler : IRequestHandler<GetAllFolderTreeQuery, Response<IReadOnlyList<FolderTree>>>
    {
        private readonly IFolderTreeRepository _repository;
        public GetAllFolderTreeQueryHandler(IFolderTreeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<IReadOnlyList<FolderTree>>> Handle(GetAllFolderTreeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAllAsync();
            if (entity == null) throw new ApiException($"Folder Not Found.");
            return new Response<IReadOnlyList<FolderTree>>(entity);
        }
    }
}
