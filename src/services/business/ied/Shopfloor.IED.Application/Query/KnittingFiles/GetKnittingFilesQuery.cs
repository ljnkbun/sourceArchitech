using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingFiles;
using Shopfloor.IED.Application.Parameters.KnittingFiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingFiles
{
    public class GetKnittingFilesQuery : IRequest<PagedResponse<IReadOnlyList<KnittingFileModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? KnittingIEDId { get; set; }
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
    public class GetKnittingFilesQueryHandler : IRequestHandler<GetKnittingFilesQuery, PagedResponse<IReadOnlyList<KnittingFileModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingFileRepository _repository;
        public GetKnittingFilesQueryHandler(IMapper mapper,
            IKnittingFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<KnittingFileModel>>> Handle(GetKnittingFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<KnittingFileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<KnittingFileParameter, KnittingFileModel>(validFilter);
        }
    }
}
