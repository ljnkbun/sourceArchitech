using AutoMapper;
using Shopfloor.Master.Application.Command.AccountGroups;
using Shopfloor.Master.Application.Models.AccountGroups;
using Shopfloor.Master.Application.Parameters.AccountGroups;
using Shopfloor.Master.Application.Query.AccountGroups;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.AccountGroups
{
    public class AccountGroupProfile : Profile
    {
        public AccountGroupProfile()
        {
            CreateMap<AccountGroup, AccountGroupModel>().ReverseMap();
            CreateMap<CreateAccountGroupCommand, AccountGroup>();
            CreateMap<GetAccountGroupsQuery, AccountGroupParameter>();
        }
    }
}
