using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingTBRequestFiles;
using Shopfloor.IED.Application.Parameters.DyeingTBRequestFiles;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingTBRequestFiles
{
    public class GetDyeingTBRequestFilesQuery : IRequest<PagedResponse<IReadOnlyList<DyeingTBRequestFileModel>>>, ICacheableMediatrQuery
    {
        public int? DyeingTBRequestId { get; set; }

        public FileType? FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }

        #region Base Properties

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

        public string CacheKey => $"DyeingTBRequestFiles";

        public TimeSpan? SlidingExpiration { get; set; }

        #endregion Base Properties
    }

    public class GetDyeingTBRequestFilesQueryHandler : IRequestHandler<GetDyeingTBRequestFilesQuery, PagedResponse<IReadOnlyList<DyeingTBRequestFileModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingTBRequestFileRepository _repository;

        public GetDyeingTBRequestFilesQueryHandler(IMapper mapper,
            IDyeingTBRequestFileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<DyeingTBRequestFileModel>>> Handle(GetDyeingTBRequestFilesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<DyeingTBRequestFileParameter>(request);
            return await _repository.GetModelPagedReponseAsync<DyeingTBRequestFileParameter, DyeingTBRequestFileModel>(validFilter);
        }
    }
}