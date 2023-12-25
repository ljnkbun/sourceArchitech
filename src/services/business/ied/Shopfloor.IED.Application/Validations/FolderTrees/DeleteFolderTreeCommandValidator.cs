using FluentValidation;
using Shopfloor.IED.Application.Command.FolderTrees;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.FolderTrees
{
    public class DeleteFolderTreeCommandValidator : AbstractValidator<DeleteFolderTreeCommand>
    {
        private readonly IFolderTreeRepository _folderTreeRepository;
        public DeleteFolderTreeCommandValidator(IFolderTreeRepository folderTreeRepository)
        {
            _folderTreeRepository = folderTreeRepository;

            RuleFor(p => p).MustAsync(IsNotInUseAsync).WithMessage("Folder is in use.");
        }
        private async Task<bool> IsNotInUseAsync(DeleteFolderTreeCommand command, CancellationToken token)
        {
            return await _folderTreeRepository.IsNotInUseAsync(command.Id);
        }
    }
}
