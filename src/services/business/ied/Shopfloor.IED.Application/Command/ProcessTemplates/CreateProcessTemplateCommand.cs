using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.ProcessTemplates
{
    public class CreateProcessTemplateCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
    public class CreateProcessTemplateCommandHandler : IRequestHandler<CreateProcessTemplateCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProcessTemplateRepository _repository;
        public CreateProcessTemplateCommandHandler(IMapper mapper,
            IProcessTemplateRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProcessTemplateCommand ProcessTemplate, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProcessTemplate>(ProcessTemplate);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
