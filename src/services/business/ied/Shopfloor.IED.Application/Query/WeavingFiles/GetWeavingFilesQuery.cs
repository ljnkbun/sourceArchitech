using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingFiles;
using Shopfloor.IED.Application.Parameters.WeavingFiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingFiles
{
    public class GetWeavingFilesQuery : IRequest<PagedResponse<IReadOnlyList<WeavingFileModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingIEDId { get; set; }
        public FileType? FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetWeavingFilesQueryHandler : IRequestHandler<GetWeavingFilesQuery, PagedResponse<IReadOnlyList<WeavingFileModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingFileRepository _repository;
        public GetWeavingFilesQueryHandler(IMapper mapper,
            IWeavingFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingFileModel>>> Handle(GetWeavingFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingFileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingFileParameter, WeavingFileModel>(validFilter);
        }
    }
}
