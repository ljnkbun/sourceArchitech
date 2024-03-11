using FluentValidation;
using Microsoft.Extensions.Configuration;
using Shopfloor.FileStorage.Application.Command.Files;
using Shopfloor.FileStorage.Application.Definations;
using Shopfloor.FileStorage.Application.Extensions;

namespace Shopfloor.FileStorage.Application.Validations.Files
{
    public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
    {
        public UploadFileCommandValidator(IConfiguration configuration)
        {
            long maxSize = 0;
            string allowExtension = "";

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                _ = long.TryParse(configuration["FileStorageSettings:Size"], out maxSize);
                allowExtension = configuration["FileStorageSettings:AllowExtension"];
            }
            else
            {
                _ = long.TryParse(Environment.GetEnvironmentVariable("FileStorageSettings_Size"), out maxSize);
                allowExtension = Environment.GetEnvironmentVariable("FileStorageSettings_AllowExtension");
            }

            RuleFor(p => p.File).NotNull().WithMessage("{PropertyName} must not be null.");

            RuleFor(p => p.Folder)
                .Must(Folder.Contains).WithMessage("Folder is not exist.");

            RuleFor(p => p.File.Length)
                .GreaterThan(0).WithMessage("File length must greater than 0.")
                .LessThanOrEqualTo(maxSize).WithMessage($"File length must less than {maxSize / 1024 / 1024} Megabyte.");

            RuleFor(p => p.File.GetExtension())
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 200 characters.")
                .Must(allowExtension.Contains).WithMessage($"File extension must be ({allowExtension}).");
        }
    }
}
