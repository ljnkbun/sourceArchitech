using FluentValidation;
using Shopfloor.Inspection.Application.Command.QCDefinitions;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.QCDefinitions
{
    public class DeleteQCDefinitionCommandValidator : AbstractValidator<DeleteQCDefinitionCommand>
    {
        IQCDefinitionRepository _repository;
        IQCRequestRepository _repositoryQCRequest;
        public DeleteQCDefinitionCommandValidator(IQCDefinitionRepository repository, IQCRequestRepository repositoryQCRequest)
        {
            _repository = repository;
            RuleFor(r => r.Id).GreaterThan(0).WithMessage("{PropertyName}  is required.").MustAsync(IsNotUsedAsync).WithMessage("{PropertyName} is used."); ;
            _repositoryQCRequest = repositoryQCRequest;
        }
        private async Task<bool> IsNotUsedAsync(int id, CancellationToken cancellationToken)
        {
            var qcDefinition= await _repository.GetByIdAsync(id);
            return !await _repositoryQCRequest.IsUsedAsync(qcDefinition.Code);

        }
    }
}
