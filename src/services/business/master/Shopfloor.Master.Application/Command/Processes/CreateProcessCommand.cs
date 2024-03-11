using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Processes
{
    public class CreateProcessCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DefaultArticleOutput { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductGroupId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? SubCategoryGroupId { get; set; }
        public int? DivisionId { get; set; }
    }

    public class CreateProcessCommandHandler : IRequestHandler<CreateProcessCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IProcessRepository _repository;

        public CreateProcessCommandHandler(IMapper mapper,
            IProcessRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Process>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}