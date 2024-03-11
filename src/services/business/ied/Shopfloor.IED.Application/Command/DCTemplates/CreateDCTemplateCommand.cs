using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.DCTemplateTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DCTemplates
{
    public class CreateDCTemplateCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<CreateDCTemplateTaskCommand> DCTemplateTasks { get; set; }
    }

    public class CreateDCTemplateCommandHandler : IRequestHandler<CreateDCTemplateCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IDCTemplateRepository _repository;

        public CreateDCTemplateCommandHandler(IMapper mapper,
            IDCTemplateRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDCTemplateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.DCTemplate>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}