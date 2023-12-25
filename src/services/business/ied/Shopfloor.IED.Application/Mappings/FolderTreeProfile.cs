using AutoMapper;
using Shopfloor.IED.Application.Command.FolderTrees;
using Shopfloor.IED.Application.Models.FolderTrees;
using Shopfloor.IED.Application.Parameters.FolderTrees;
using Shopfloor.IED.Application.Query.FolderTrees;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.FolderTrees
{
    public class FolderTreeProfile : Profile
    {
        public FolderTreeProfile()
        {
            CreateMap<FolderTree, FolderTreeModel>().ReverseMap();
            CreateMap<CreateFolderTreeCommand, FolderTree>();
            CreateMap<GetFolderTreesQuery, FolderTreeParameter>();
        }
    }
}
