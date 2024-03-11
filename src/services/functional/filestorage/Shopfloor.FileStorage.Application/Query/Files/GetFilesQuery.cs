using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.FileStorage.Application.Models;
using Shopfloor.FileStorage.Application.Parameters.Files;
using Shopfloor.FileStorage.Domain.Interfaces;

namespace Shopfloor.FileStorage.Application.Query.Files
{
    public class GetFilesQuery : IRequest<PagedResponse<IReadOnlyList<FileModel>>>, ICacheableMediatrQuery
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public long? Size { get; set; }
        public string Folder { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Files";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetFilesQueryHandler : IRequestHandler<GetFilesQuery, PagedResponse<IReadOnlyList<FileModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IFileRepository _repository;
        public GetFilesQueryHandler(IMapper mapper,
            IFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<FileModel>>> Handle(GetFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<FileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<FileParameter, FileModel>(validFilter);
        }
    }
}
