using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestDivisionFiles
{
    public class CreateRequestDivisionFileCommand : IRequest<Response<int>>
    {
        public int RequestDivisionId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
    }
    public class CreateRequestDivisionFileCommandHandler : IRequestHandler<CreateRequestDivisionFileCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRequestDivisionFileRepository _repository;
        public CreateRequestDivisionFileCommandHandler(IMapper mapper,
            IRequestDivisionFileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRequestDivisionFileCommand RequestDivisionFile, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<RequestDivisionFile>(RequestDivisionFile);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
