using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingIEDs
{
    public class CreateKnittingIEDCommand : IRequest<Response<int>>
    {
        public int RequestArticleOutputId { get; set; }
        public int? ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Buyer { get; set; }
        public string Remark { get; set; }
        public Status Status { get; set; }
    }
    public class CreateKnittingIEDCommandHandler : IRequestHandler<CreateKnittingIEDCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingIEDRepository _repository;
        public CreateKnittingIEDCommandHandler(IMapper mapper,
            IKnittingIEDRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateKnittingIEDCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<KnittingIED>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
