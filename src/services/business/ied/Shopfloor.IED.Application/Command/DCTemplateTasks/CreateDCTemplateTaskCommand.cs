﻿using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DCTemplateDetails;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DCTemplateTasks
{
    public class CreateDCTemplateTaskCommand : IRequest<Response<int>>
    {
        public int DCTemplateId { get; set; }
        public int TaskId { get; set; }
        public string TaskCode { get; set; }
        public string TaskName { get; set; }
        public string Temperature { get; set; }
        public int Minute { get; set; }
        public virtual ICollection<CreateDCTemplateDetailCommand> DCTemplateDetails { get; set; }
    }

    public class CreateDCTemplateTaskCommandHandler : IRequestHandler<CreateDCTemplateTaskCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDCTemplateTaskRepository _repository;

        public CreateDCTemplateTaskCommandHandler(IMapper mapper,
            IDCTemplateTaskRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDCTemplateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DCTemplateTask>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}