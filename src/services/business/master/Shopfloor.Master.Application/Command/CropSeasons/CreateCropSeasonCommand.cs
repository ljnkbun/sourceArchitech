using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.CropSeasons
{
    public class CreateCropSeasonCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateCropSeasonCommandHandler : IRequestHandler<CreateCropSeasonCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICropSeasonRepository _repository;
        public CreateCropSeasonCommandHandler(IMapper mapper,
            ICropSeasonRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCropSeasonCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CropSeason>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
