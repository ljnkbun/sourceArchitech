using MediatR;
using Shopfloor.Barcode.Application.Models.Locations;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Barcode.Application.Query.Locations
{
    public class PrintLocationsQuery : IRequest<ICollection<PrintLocationModel>>
    {
        public string Ids { get; set; }
    }
    public class PrintLocationsQueryHandler : IRequestHandler<PrintLocationsQuery, ICollection<PrintLocationModel>>
    {
        private readonly ILocationRepository _repository;
        private readonly IRequestClientService _requestClientService;

        public PrintLocationsQueryHandler(
            ILocationRepository repository
            , IRequestClientService requestClientService
            )
        {
            _repository = repository;
            _requestClientService = requestClientService;
        }

        public async Task<ICollection<PrintLocationModel>> Handle(PrintLocationsQuery request, CancellationToken cancellationToken)
        {
            var intIds = request.Ids.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            var locs = await _repository.GetByIdsAsync(intIds);

            var rs = new List<PrintLocationModel>();

            foreach (var loc in locs.Where(x => intIds.Contains(x.Id)))
            {
                rs.Add(new()
                {
                    Id = loc.Id,
                    Location = loc.Name,
                    Barcode = loc.Barcode,
                    Site = locs.FirstOrDefault(x => x.Id == loc.ParentLocationId)?.Name,
                    ParentLocationId = loc.ParentLocationId,
                    LevelLocation = loc.LevelLocation,
                });
            }

            return rs;
        }
    }
}
