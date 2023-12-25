using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Grades
{
    public class CreateGradeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IGradeRepository _repository;
        public CreateGradeCommandHandler(IMapper mapper,
            IGradeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Grade>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
