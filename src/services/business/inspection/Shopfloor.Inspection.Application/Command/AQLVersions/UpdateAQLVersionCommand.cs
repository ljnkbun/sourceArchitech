using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Inspection.Application.Command.AQLs;
using AutoMapper;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Command.AQLVersions
{
    public class UpdateAQLVersionCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        
        public bool IsActive { set; get; }
        public ICollection<UpdateAQLCommand> AQLs { get; set; }
    }
    public class UpdateAQLVersionCommandHandler : IRequestHandler<UpdateAQLVersionCommand, Response<int>>
    {
        private readonly IAQLVersionRepository _repository;
        private readonly IMapper _mapper;
        public UpdateAQLVersionCommandHandler(IAQLVersionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateAQLVersionCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAQLVersionByIdAsync(command.Id);

            if (entity == null) return new($"AQLVersion Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            var insertedAQLs =  _mapper.Map<ICollection<AQL>>(command.AQLs);
            var deletedAQLs = entity.AQLs;
            await _repository.UpdateAQLVersionAsync(entity, deletedAQLs, insertedAQLs);


            return new Response<int>(entity.Id);
        }
    }
}
