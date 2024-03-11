using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.FileStorage.Domain.Interfaces;
using Shopfloor.FileStorage.Infrastructure.Contexts;

namespace Shopfloor.FileStorage.Infrastructure.Repositories
{
    public class FileRepository : GenericRepositoryAsync<Domain.Entities.File>, IFileRepository
    {
        public FileRepository(FileStorageContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
