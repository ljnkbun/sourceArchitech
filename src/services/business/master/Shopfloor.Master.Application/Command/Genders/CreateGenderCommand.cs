using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Genders
{
    public class CreateGenderCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateGenderCommandHandler : IRequestHandler<CreateGenderCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _repository;
        public CreateGenderCommandHandler(IMapper mapper,
            IGenderRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Gender>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
