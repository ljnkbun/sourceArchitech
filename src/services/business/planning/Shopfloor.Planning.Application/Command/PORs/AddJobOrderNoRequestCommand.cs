using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Application.Models.PORs;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.PORs
{
    public class AddJobOrderNoRequestCommand : IRequest<Response<PORModel>>
    {
        public int Id { get; set; }
    }
    public class AddJobOrderNoRequestCommandHandler : IRequestHandler<AddJobOrderNoRequestCommand, Response<PORModel>>
    {
        private readonly IMapper _mapper;
        private readonly IPORRepository _repository;

        public AddJobOrderNoRequestCommandHandler(IMapper mapper
            , IPORRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<PORModel>> Handle(AddJobOrderNoRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return new($"POR Not Found (Id:{request.Id})");
            if (!string.IsNullOrEmpty(entity.JobOrderNo))
                return new($"JobOrderNo already exists (Id:{request.Id}).");

            var result = await _repository.AddJobOrderNoRequestAsync(entity);

            return new Response<PORModel>(_mapper.Map<PORModel>(result));
        }
    }
}
