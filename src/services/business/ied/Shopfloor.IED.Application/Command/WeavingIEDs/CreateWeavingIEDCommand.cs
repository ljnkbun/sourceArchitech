﻿using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingIEDs
{
    public class CreateWeavingIEDCommand : IRequest<Response<int>>
    {
        public int RequestDivisionId { get; set; }
        public string RequestNo { get; set; }
        public string Comment { get; set; }
        public Status Status { get; set; }
    }
    public class CreateWeavingIEDCommandHandler : IRequestHandler<CreateWeavingIEDCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingIEDRepository _repository;
        public CreateWeavingIEDCommandHandler(IMapper mapper,
            IWeavingIEDRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingIEDCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingIED>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
