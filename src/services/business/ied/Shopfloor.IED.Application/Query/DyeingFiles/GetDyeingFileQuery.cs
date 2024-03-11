using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.DyeingFiles
{
    public class GetDyeingFileQuery : IRequest<Response<DyeingFile>>
    {
        public int Id { get; set; }
    }
    public class GetDyeingFileQueryHandler : IRequestHandler<GetDyeingFileQuery, Response<DyeingFile>>
    {
        private readonly IDyeingFileRepository _repository;
        public GetDyeingFileQueryHandler(IDyeingFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<DyeingFile>> Handle(GetDyeingFileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DyeingFile Not Found (Id:{query.Id}).");
            return new Response<DyeingFile>(entity);
        }
    }
}
