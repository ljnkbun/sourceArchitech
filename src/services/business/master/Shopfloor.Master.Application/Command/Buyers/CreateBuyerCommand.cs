﻿using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Buyers
{
    public class CreateBuyerCommand : IRequest<Response<int>>
    {
        public string WFXBuyerId { get; set; }
        public string Name { get; set; }
    }

    public class CreateBuyerCommandHandler : IRequestHandler<CreateBuyerCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IBuyerRepository _repository;

        public CreateBuyerCommandHandler(IMapper mapper,
            IBuyerRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBuyerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Buyer>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}