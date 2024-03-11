using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.AppVersions
{
    public class CreateAppVersionCommand : IRequest<Response<int>>
    {
        public int FileId { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
    }

    public class CreateAppVersionCommandHandler : IRequestHandler<CreateAppVersionCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IAppVersionRepository _repository;

        public CreateAppVersionCommandHandler(IMapper mapper,
            IAppVersionRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateAppVersionCommand AppVersion, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<AppVersion>(AppVersion);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}