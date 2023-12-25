using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Themes
{
    public class CreateThemeCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateThemeCommandHandler : IRequestHandler<CreateThemeCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IThemeRepository _repository;
        public CreateThemeCommandHandler(IMapper mapper,
            IThemeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateThemeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Theme>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
