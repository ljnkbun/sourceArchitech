using AutoMapper;
using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingFiles;
using Shopfloor.IED.Application.Parameters.DyeingFiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingFiles
{
    public class GetDyeingFilesQuery : IRequest<PagedResponse<IReadOnlyList<DyeingFileModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? DyeingIEDId { get; set; }
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
    public class GetDyeingFilesQueryHandler : IRequestHandler<GetDyeingFilesQuery, PagedResponse<IReadOnlyList<DyeingFileModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingFileRepository _repository;
        public GetDyeingFilesQueryHandler(IMapper mapper,
            IDyeingFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingFileModel>>> Handle(GetDyeingFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingFileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingFileParameter, DyeingFileModel>(validFilter);
        }
    }
}
