using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Command.WeavingRappoMarks;
using Shopfloor.IED.Application.Command.WeavingRappoMatrics;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRappos
{
    public class UpdateWeavingRappoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int Line { get; set; }
        public int WarpPerMarginDentSplit { get; set; }
        public int WarpPerContentDentSplit { get; set; }
        public int TotalRappo { get; set; }
        public int AdditionYarn { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public string DrawingComment { get; set; }
        public bool IsActive { set; get; }
        public ICollection<UpdateWeavingRappoMarkCommand> WeavingRappoMarks { get; set; }
        public ICollection<UpdateWeavingRappoMatricCommand> WeavingRappoMatrics { get; set; }
    }
    public class UpdateWeavingRappoCommandHandler : IRequestHandler<UpdateWeavingRappoCommand, Response<int>>
    {
        private readonly IWeavingRappoRepository _repository;
        private readonly IWeavingRappoMarkRepository _repositoryMark;
        private readonly IWeavingRappoMatricRepository _repositoryMatric;


        public UpdateWeavingRappoCommandHandler(IWeavingRappoRepository repository, IWeavingRappoMarkRepository repositoryMark, IWeavingRappoMatricRepository repositoryMatric)
        {
            _repository = repository;
            _repositoryMark = repositoryMark;
            _repositoryMatric = repositoryMatric;
        }
        public async Task<Response<int>> Handle(UpdateWeavingRappoCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingRappo Not Found.");

            entity.Line = command.Line;
            entity.WarpPerMarginDentSplit = command.WarpPerMarginDentSplit;
            entity.WarpPerContentDentSplit = command.WarpPerContentDentSplit;
            entity.TotalRappo = command.TotalRappo;
            entity.VerticalRappoComment = command.VerticalRappoComment;
            entity.HorizontalRappoComment = command.HorizontalRappoComment;
            entity.DrawingComment = command.DrawingComment;
            entity.IsActive = command.IsActive;

            var deleteMarks = await _repositoryMark.GetListAsync(command.Id);
            var deleteMatrics = await _repositoryMatric.GetListAsync(command.Id); 
            var insertMarks = command.WeavingRappoMarks?.Select(x => new WeavingRappoMark
                {
                    WeavingRappoId = command.Id,
                    ColumnNo = x.ColumnNo,
                    PatternIndex = x.PatternIndex,
                    Type = x.Type
                }).ToList();
            var insertMatrics = command.WeavingRappoMatrics?.Select(x => new WeavingRappoMatric
                {
                    WeavingRappoId = command.Id,
                    SlotIndex = x.SlotIndex,
                    RowIndex = x.RowIndex,
                    ColumnIndex = x.ColumnIndex,
                    LoopIndex = x.LoopIndex,
                    HorizontalYarnId = x.HorizontalYarnId,
                    VerticleYarnId = x.VerticleYarnId,
                    BackgroundType = x.BackgroundType,
                    IsActive = x.IsActive
                }).ToList();

            await _repository.UpdateWeavingRappoAsync(entity, deleteMarks, deleteMatrics, insertMarks, insertMatrics);
            return new Response<int>(entity.Id);
        }
    }
}
