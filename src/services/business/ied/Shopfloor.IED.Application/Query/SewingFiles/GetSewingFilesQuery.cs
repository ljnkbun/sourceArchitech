using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingFiles;
using Shopfloor.IED.Application.Parameters.SewingFiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingFiles
{
    public class GetSewingFilesQuery : IRequest<PagedResponse<IReadOnlyList<SewingFileModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? SewingIEDId { get; set; }
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
    public class GetSewingFilesQueryHandler : IRequestHandler<GetSewingFilesQuery, PagedResponse<IReadOnlyList<SewingFileModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingFileRepository _repository;
        public GetSewingFilesQueryHandler(IMapper mapper,
            ISewingFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<SewingFileModel>>> Handle(GetSewingFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<SewingFileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<SewingFileParameter, SewingFileModel>(validFilter);
        }
    }
}
