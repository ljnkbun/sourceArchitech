﻿using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Enums.LevelLocations;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Locations
{
    public class CreateLocationCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public int? ParentLocationId { get; set; }
        public LevelLocation? LevelLocation { get; set; }
    }
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _repository;
        public CreateLocationCommandHandler(IMapper mapper,
            ILocationRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Location>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
