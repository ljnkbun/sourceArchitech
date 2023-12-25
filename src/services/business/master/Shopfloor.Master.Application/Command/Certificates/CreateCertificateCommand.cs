using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Certificates
{
    public class CreateCertificateCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _repository;
        public CreateCertificateCommandHandler(IMapper mapper,
            ICertificateRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Certificate>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
