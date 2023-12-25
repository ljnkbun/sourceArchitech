using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.ProcessTemplateItems
{
    public class CreateProcessTemplateItemCommand : IRequest<Response<int>>
    {
        public int ProcessTemplateId { get; set; }
        public int Division { get; set; }
        public int Priority { get; set; }

    }
    public class CreateProcessTemplateItemCommandHandler : IRequestHandler<CreateProcessTemplateItemCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProcessTemplateItemRepository _repository;
        public CreateProcessTemplateItemCommandHandler(IMapper mapper,
            IProcessTemplateItemRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProcessTemplateItemCommand ProcessTemplateItem, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProcessTemplateItem>(ProcessTemplateItem);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
