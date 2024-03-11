using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

public class CreateLearningCurveDetailEfficiencyCommand : IRequest<Response<int>>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int? LearningCurveEfficiencyId { get; set; }
    public int? Days { get; set; }
    public decimal? EfficiencyValue { get; set; }
}
public class CreateLearningCurveDetailEfficiencyCommandHandler : IRequestHandler<CreateLearningCurveDetailEfficiencyCommand, Response<int>>
{
    private readonly IMapper _mapper;
    private readonly ILearningCurveDetailEfficiencyRepository _repository;
    public CreateLearningCurveDetailEfficiencyCommandHandler(IMapper mapper,
        ILearningCurveDetailEfficiencyRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateLearningCurveDetailEfficiencyCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<LearningCurveDetailEfficiency>(request);
        await _repository.AddAsync(entity);
        return new Response<int>(entity.Id);
    }
}
