using AutoMapper;
using MediatR;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Master.Application.Command.Holidays
{
    public class CreateHolidayCommand : IRequest<Response<int>>
    {
        public DateTime? Date { get; set; }
		public string Description { get; set; }
    }
    public class CreateHolidayCommandHandler : IRequestHandler<CreateHolidayCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IHolidayRepository _repository;
        public CreateHolidayCommandHandler(IMapper mapper,
            IHolidayRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateHolidayCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Holiday>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
