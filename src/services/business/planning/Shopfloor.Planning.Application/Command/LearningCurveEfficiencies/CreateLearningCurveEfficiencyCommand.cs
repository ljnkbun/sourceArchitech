using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

public class CreateLearningCurveEfficiencyCommand : IRequest<Response<int>>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
public class CreateLearningCurveEfficiencyCommandHandler : IRequestHandler<CreateLearningCurveEfficiencyCommand, Response<int>>
{
    private readonly IMapper _mapper;
    private readonly ILearningCurveEfficiencyRepository _repository;
    public CreateLearningCurveEfficiencyCommandHandler(IMapper mapper,
        ILearningCurveEfficiencyRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateLearningCurveEfficiencyCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<LearningCurveEfficiency>(request);
        await _repository.AddAsync(entity);
        return new Response<int>(entity.Id);
    }
}
