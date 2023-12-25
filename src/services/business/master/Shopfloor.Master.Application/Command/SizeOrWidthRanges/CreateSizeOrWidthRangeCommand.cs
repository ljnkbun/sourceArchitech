using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SizeOrWidthRanges
{
    public class CreateSizeOrWidthRangeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
    }
    public class CreateSizeOrWidthRangeCommandHandler : IRequestHandler<CreateSizeOrWidthRangeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISizeOrWidthRangeRepository _repository;
        public CreateSizeOrWidthRangeCommandHandler(IMapper mapper,
            ISizeOrWidthRangeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSizeOrWidthRangeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SizeOrWidthRange>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
