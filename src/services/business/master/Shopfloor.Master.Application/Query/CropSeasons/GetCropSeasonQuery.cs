using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CropSeasons
{
    public class GetCropSeasonQuery : IRequest<Response<CropSeason>>
    {
        public int Id { get; set; }
    }
    public class GetCropSeasonQueryHandler : IRequestHandler<GetCropSeasonQuery, Response<CropSeason>>
    {
        private readonly ICropSeasonRepository _repository;
        public GetCropSeasonQueryHandler(ICropSeasonRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<CropSeason>> Handle(GetCropSeasonQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"CropSeason Not Found (Id:{query.Id}).");
            return new Response<CropSeason>(entity);
        }
    }
}
